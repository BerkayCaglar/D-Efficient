using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AIManager : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatisGround;
    public LayerMask WhatisPlayer;

    //patrol
    private Vector3 WalkPoint;
    private bool WalkPointSet;
    public float WalkPointRange;
    
    //states
    public float SightRange;
    public float AttackRange;
    public bool PlayerInsightRange;
    public bool PlayerInAttackRange;
    
    //Can&Hit

    public float Hit;
    private Text HealthText;
    public float health;
    private bool AttackBool = true;
    
    private void Awake()
    {
        //player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(AttackWait());
    }

    private void Update()
    {
        //HealthText.text = health.ToString();
        PlayerInsightRange = Physics.CheckSphere(transform.position, SightRange, WhatisPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatisPlayer);

        if (!PlayerInsightRange && !PlayerInAttackRange)
        {
            Patroling();
        }
        if (PlayerInsightRange && !PlayerInAttackRange)
        {
            ChasePlayer();
        }
        if (PlayerInsightRange && PlayerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!WalkPointSet)
        {
            SearchWalkPoint();
        }

        if (WalkPointSet)
        {
            agent.destination = WalkPoint;
        }

        Vector3 distanceToWalkPoint = transform.position - WalkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            WalkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(WalkPoint, -transform.up, 2f, WhatisGround));
        {
            WalkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        agent.destination = player.transform.position;
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        //transform.LookAt(player);

        if (AttackBool)
        {
            health = health - Hit;
            AttackBool = false;
            StartCoroutine(AttackWait());
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy),0.5f);
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SightRange);
    }
    IEnumerator AttackWait()
    {
        if (!AttackBool)
        {
            yield return new WaitForSecondsRealtime(2f);
            AttackBool = true;
        }
    }
}
