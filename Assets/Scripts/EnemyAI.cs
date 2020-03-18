using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRadius = 25.0f;
    [SerializeField] [Range(0, 100)] private int damage = 1;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private Transform target = null;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Player>().transform;
    }


    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget < chaseRadius)
        {
            isProvoked = true;
        }
    }


    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        } 
        else
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        print(name + " is attacking " + target.name + "!");
        var health = target.GetComponent<Health>();
        
        if (health)
        {
            health.Damage(damage);
        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
