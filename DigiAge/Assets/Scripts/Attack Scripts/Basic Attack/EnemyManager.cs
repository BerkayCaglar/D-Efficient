using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static public class BasicEnemyProperties

    {
        static public float health { get; set;} = 100f;
        static public float damage { get; private set;} = 10f;
        static public float speed { get; private set;} = 10f;
    }
    
    static public class MidLevelEnemyProperties

    {
        static public float health { get; set;} = 200f;
        static public float damage { get; private set;} = 25f;
        static public float speed { get; private set;} = 5f;
    }

    public static void EnemyShaker(GameObject enemy)
    {
        Animator enemyAnimator = enemy.GetComponent<Animator>();
        if (enemy.GetComponent<BasicEnemy>())
        {
            enemyAnimator.Play("HitAnimation");
        }
    }
}