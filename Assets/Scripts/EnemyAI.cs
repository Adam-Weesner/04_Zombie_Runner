using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5.0f;
    private float distanceToTarget = Mathf.Infinity;
    private Transform target = null;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget < chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}
