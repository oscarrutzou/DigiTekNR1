using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] int healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController p = collision.GetComponent<PlayerController>();

        if (p != null)
        {
            Debug.Log("Healing");
            p.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
