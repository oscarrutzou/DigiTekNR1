using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWeapon : MonoBehaviour
{
    [SerializeField] private float timeAlive = 2f;
    [SerializeField] private float timer;

    private void OnEnable()
    {
        timer = timeAlive;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
