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
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        if (GetComponent<Player>())
        {
            print("Player dead!");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
