using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown((0)) && IsEnemyOnRange.IsOnRange && IsEnemyOnRange.EnemiesInRange.Count !=0)
        {
            ResultOfAttack();
            CamControl.ShakeStarter = true;
        }

    }

    private void ResultOfAttack()
    {
        foreach (GameObject i in IsEnemyOnRange.EnemiesInRange)
        {
            if (i.GetComponent<BasicEnemy>() != null)
            {
                i.GetComponent<BasicEnemy>().Health -= 20;
                EnemyManager.EnemyShaker(i);
            }
            
        }
    }
}