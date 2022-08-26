using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{

    [SerializeField] GameObject healtPickUp;
    [SerializeField]
    [Range(0f, 1f)] float chance = 1f;

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (isQuitting) { return; }

        if (Random.value < chance)
        {
            Transform t = Instantiate(healtPickUp).transform;
            t.position = transform.position;

        }
    }
}
