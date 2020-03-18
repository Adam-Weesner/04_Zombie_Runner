using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private int damage = 1;
    private Transform target = null;

    private void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    public void AttackHitEvent()
    {
        print("Hitting player!");
        var health = target.GetComponent<Health>();

        if (health)
        {
            health.Damage(damage);
        }
    }
}
