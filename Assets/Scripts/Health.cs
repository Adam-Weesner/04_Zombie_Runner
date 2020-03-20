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
            SendMessage(nameof(Die));
        }
    }

    private void Die() { }

    private void OnDamageTaken() { }
}
