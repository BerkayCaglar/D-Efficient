using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackScript : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetMouseButtonDown((0)) && IsEnemyOnRange.IsOnRange && IsEnemyOnRange.EnemyGameObject != null)
        {
            if (IsEnemyOnRange.EnemyGameObject.name == "Basic Enemy")
            {
                IsEnemyOnRange.EnemyGameObject.GetComponent<BasicEnemy>().Health -= 20;
                EnemyManager.EnemyShaker(IsEnemyOnRange.EnemyGameObject);
            }

            CamControl.ShakeStarter = true;
        }
    }
}