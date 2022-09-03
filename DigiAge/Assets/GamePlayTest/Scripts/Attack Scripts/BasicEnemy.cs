using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Enemy Properties")]
    private float _health = EnemyManager.BasicEnemyProperties.health;
    
    private float _damage = EnemyManager.BasicEnemyProperties.damage;
    
    private float _speed  = EnemyManager.BasicEnemyProperties.speed;
    
    public float Health
    {
        get => _health;
        set => _health = Mathf.Max(0, value);
    }

    public float damage
    {
        get { return _damage; }
    }
    public float speed
    {
        get { return _speed; }
    }
    private void Update()
    {
        if(Health < 1) Destroy(gameObject);
    }
}