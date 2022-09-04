using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    
    //Attack
    public float TimeBetweenAttacks;
    private bool AlreadyAttacked;

    //public GameObject projecttile;
    
    //states
    public float SightRange;
    public float AttackRange;
    public bool PlayerInsightRange;
    public bool PlayerInAttackRange;

    public float health;
    
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
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
        transform.LookAt(player);

        if (!AlreadyAttacked)
        {
            //Rigidbody rb = Instantiate(projecttile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
           // rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
          //  rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            
            AlreadyAttacked = true;
            Invoke(nameof(ResetAttack),TimeBetweenAttacks);
        }
    }

    private void ResetAttack()
    { 
        AlreadyAttacked = false;
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
}
