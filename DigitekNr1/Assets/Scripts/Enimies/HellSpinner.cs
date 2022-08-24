using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class HellSpinner : MonoBehaviour
{
    public Transform target;

    [SerializeField] int health = 100;
    [SerializeField] int damage = 10;
    

    private Rigidbody2D rb;

    [SerializeField] private int accelerationSpeed = 10;
    [SerializeField] private int speedCap = 100;
    private int rotationSpeed = 720;

    private Vector2 moveDirection;


    #region Oscar
    [SerializeField] float activateDistance = 10f;
    private GameObject targetGameObject;
    private PlayerController playerController;

    [SerializeField] int experience_reward = 400;
    #endregion


    private void Awake()
    {
        targetGameObject = GameObject.FindWithTag("Player");
        playerController = targetGameObject.GetComponent<PlayerController>();

        target = targetGameObject.transform;

        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        SetAttackVector();
    }


    private void Update()
    {
        
    }


    void FixedUpdate()
    {
        Vector2 targetRPos = (Vector2)target.position - rb.position;
        targetRPos = targetRPos.normalized;


        if (!TargetInDistance())
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (Vector2.Angle(targetRPos, moveDirection) <= 90) //target in front
        {
            if (rb.velocity.magnitude < speedCap)
            {
                rb.AddForce(moveDirection * accelerationSpeed, ForceMode2D.Force); //accelerate
            }
        }
        else
        {
            rb.AddForce(-moveDirection * accelerationSpeed, ForceMode2D.Force); //deccelerate
        }

        if (rb.velocity.magnitude < 1) //not moving
        {
            SetAttackVector(); //change direction
        }

        rb.angularVelocity = rotationSpeed;
        //Debug.Log(rb.velocity.magnitude);
    }

    void SetAttackVector()
    {
        moveDirection = (Vector2)target.position - rb.position;
        moveDirection = moveDirection.normalized;
    }


    //Damage
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("I'm triggerd");
        /*PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (hitInfo.gameObject.tag == "Player" && player != null)
        {
            player.TakeDamage(damage)
        }*/
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            playerController.GetComponent<Level>().AddExperience(experience_reward);
            Die();
        }
    }

    public void Die()
    {
        //Vector2 explosionSpot = transform.position;
        ////GameObject ExplosionM = Instantiate(ExplodeEffectM, explosionSpot, transform.rotation);
        //for (int i = 0; i < 3; i++)
        //{
        //    //GameObject ExplosionS = Instantiate(ExplodeEffectS, Random.insideUnitCircle + explosionSpot, transform.rotation);
        //}

        playerController.GetComponent<Level>().AddExperience(experience_reward);
        Destroy(gameObject);
    }

    #region Oscar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Debug.Log("HellSpinner damage to player");
            Attack();
        }
    }

    private void Attack()
    {
        playerController.TakeDamage(damage);
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.position) < activateDistance;
    }

    #endregion
}
