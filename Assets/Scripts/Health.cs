using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 5;
    private int health;

    void Start()
    {
        health = startingHealth;
    }

    public void Damage(int damage)
    {
        BroadcastMessage(nameof(OnDamageTaken));
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnDamageTaken() { }

    private void Die()
    {
        if (GetComponent<Player>())
        {
            print("Player dead!");
            var deathHandler = GetComponent<DeathHandler>();
            if (!deathHandler) { return; }
            deathHandler.OnDeath();
            print("1");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
