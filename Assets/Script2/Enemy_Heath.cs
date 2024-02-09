using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Declare a variable
    public int maxHealth = 100; 
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Method to reduce enemy's health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy's health is less than or equal to zero
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    // Method to handle enemy's death
    void Die()
    {
        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
