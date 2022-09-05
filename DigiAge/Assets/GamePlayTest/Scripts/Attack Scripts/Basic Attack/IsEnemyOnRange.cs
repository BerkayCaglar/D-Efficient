using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyOnRange : MonoBehaviour
{
    static public bool IsOnRange { get; private set; }

    public static List<GameObject> EnemiesInRange = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(("Enemy")))
        {
            IsOnRange = true;
            EnemiesInRange.Add(other.gameObject);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(("Enemy")))
        {
            IsOnRange = false;
            EnemiesInRange.Remove(other.gameObject);
        }
    }
}
