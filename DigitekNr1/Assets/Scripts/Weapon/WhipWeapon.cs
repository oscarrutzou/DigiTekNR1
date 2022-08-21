using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 2f;
    [SerializeField] private float timer;

    [SerializeField] private GameObject leftWhipObject;
    [SerializeField] private GameObject rightWhipObject;

    [SerializeField] int whipDamage = 1;

    private PlayerController playerController;
    [SerializeField] private Vector2 whipAttackSize = new Vector2(4, 2f);

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
            Debug.Log("Left");
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else 
        {
            Debug.Log("Right");
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);

        }

    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageAble f = colliders[i].GetComponent<IDamageAble>();
            if (f != null)
            {
                f.TakeDamage(whipDamage);
            }
        }
    }
}
