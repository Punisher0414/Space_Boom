using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void TakeDamage(int damage)
    {

        if (currentHealth > 0F)
        {
            currentHealth -= damage;

        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

}
