using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour, IDamageAble
{
    public void TakeDamage(int damage)
    {
        Debug.Log("Damangegeeg");
        Destroy(gameObject);
    }
}
