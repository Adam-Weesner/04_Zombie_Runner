using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAttack), typeof(Health))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float chaseRadius = 25.0f;
    [SerializeField] private float turnSpeed = 5.0f;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private Transform target = null;
    private NavMeshAgent navMeshAgent;
    private Animator anim;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Player>().transform;
        anim = GetComponent<Animator>();
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
        FaceTarget();

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
        anim.SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        anim.SetBool("attack", false);
        anim.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("dying");
        GetComponent<NavMeshAgent>().enabled = false;
        Destroy(this);
        Destroy(GetComponent<Health>());
    }
}
