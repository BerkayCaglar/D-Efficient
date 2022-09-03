using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyOnRange : MonoBehaviour
{
    static public bool IsOnRange { get; private set; }
    static public GameObject EnemyGameObject { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(("Enemy")))
        {
            IsOnRange = true;
            EnemyGameObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(("Enemy")))
        {
            IsOnRange = false;
            EnemyGameObject = null;
        }
    }
}
