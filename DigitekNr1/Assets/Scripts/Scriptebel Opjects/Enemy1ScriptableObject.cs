using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy1")]
public class Enemy1ScriptableObject : ScriptableObject
{
    public int MaxHealth = 100;

    public float Speed = 100f;
}
