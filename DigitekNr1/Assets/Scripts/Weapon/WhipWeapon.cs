using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 2f;
    [SerializeField] private float timer;

    [SerializeField] private GameObject leftWhipObject;
    [SerializeField] private GameObject rightWhipObject;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }


    private void Attack()
    {

        timer = timeToAttack;
        Debug.Log("Attack");

        if (playerController.lastXInput > 0.01)
        {
            Debug.Log("Right");
            rightWhipObject.SetActive(true);
        }
        else 
        {
            Debug.Log("Left");
            leftWhipObject.SetActive(true);
        }

    }
}
