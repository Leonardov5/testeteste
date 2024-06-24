using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;
    private Transform playersTransform;
    private NavMeshAgent enemyNavMeshAgent;

    private void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        playersTransform = FindObjectOfType<PlayerMovement>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();

        enemyNavMeshAgent.stoppingDistance = 3f;
    }

    private void Update()
    {
        if (enemyAwareness.isAggro)
        {
            enemyNavMeshAgent.SetDestination(playersTransform.position);
        }
        else if(!enemyAwareness.isAggro)
        {
            enemyNavMeshAgent.SetDestination(transform.position);
        }
    }
}
