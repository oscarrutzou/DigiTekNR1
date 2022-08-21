using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{

    [SerializeField] GameObject healtPickUp;
    [SerializeField]
    [Range(0f, 1f)] float chance = 1f;

    private void OnDestroy()
    {
        if (Random.value < chance)
        {
            Transform t = Instantiate(healtPickUp).transform;
            t.position = transform.position;

        }
    }
}
