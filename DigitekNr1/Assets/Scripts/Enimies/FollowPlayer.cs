using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FollowPlayer : MonoBehaviour
{

    [Header("Tranforms")]
    [SerializeField] Transform enemyGFX;


    private GameObject targetGameObject;
    private Transform target;


    [Header("Physics")]
    [SerializeField] float activateDistance = 10f;
    [SerializeField] float speed = 200f;
    [SerializeField] float nextWaypointDistance = 3f;

    //[SerializeField] 
    //float timeBetweenSpawn = 3f;

    //Til at spille lyd

    //private GameObject manager;
    //private AudioManager audioManager;


    Path path;
    private int currentWaypoint = 0;
    //private bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        targetGameObject = GameObject.FindWithTag("Player");
        target = targetGameObject.transform;


        //currentTime = startingTime;

        //manager = GameObject.Find("AudioManager");
        //audioManager = manager.GetComponent<AudioManager>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }


    void FixedUpdate()
    {
        if (path == null)
            return;

        if (TargetInDistance())
        {
            if (currentWaypoint >= path.vectorPath.Count)
            {
                //reachedEndOfPath = true;
                return;
            }
            else
            {
                //reachedEndOfPath = false;
            }


            //For at finde direction hen til playeren.
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

            //Til at flippe side.
            if (direction.x >= 0.01f)
            {
                enemyGFX.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (direction.x <= -0.01f)
            {
                enemyGFX.transform.localScale = new Vector3(1f, 1f, 1f);
            }

            //Sætter velocity til rb
            rb.velocity = direction * speed * Time.deltaTime;

            //rb.AddForce(force);

            //Finder distancen mellem spilleren og enemy.
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            //Laver nyt waypoint hvis den er under et bestemt tal.
            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            //Sætter velocity til 0 når man ikke kan se spilleren.
            rb.velocity = Vector2.zero;

            return;
        }
    }


    //For at hjekke om spilleren er indenfor det område man har valgt.
    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.position) < activateDistance;
    }

    //Updater path hvis den er færdig og man er indefor rækkevide.
    void UpdatePath()
    {
        if (seeker.IsDone() && TargetInDistance())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    //Kaldt når pathen er complete.
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    //public void Damage(float amount)
    //{
    //    Debug.Log(amount + "Damage");
    //    Destroy(gameObject);
    //}


    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        Destroy(gameObject); //Så den ikke følger efter en hele tiden
    //    }
    //}
}
