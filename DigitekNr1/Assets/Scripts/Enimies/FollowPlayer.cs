using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FollowPlayer : MonoBehaviour
{

    [Header("Tranforms")]
    [SerializeField] Transform enemyGFX;

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

        target = GameObject.FindWithTag("Player").transform;
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

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            rb.velocity = direction * speed * Time.deltaTime;

            //rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            return;
        }


    }



    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.position) < activateDistance;
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && TargetInDistance())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

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
