using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    private float timeToAttack = 4f;
    private float timer;

    [SerializeField] private GameObject leftWhipObject;
    [SerializeField] private GameObject rightWhipObject;
    
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
    }
}
