using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth ;
    public bool isAlive{ get; private set; } 

    private void Awake()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckAlive();
    }

    private void CheckAlive()
    {
        if (currentHealth <= 0)
        {
            isAlive = false;
        }
        else
        {
            isAlive = true;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
