using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private float currentHealth;
    public float healthPerSecond;
    public float startRegenerationTime;
    private float regenerationTime;
    public Slider healthSlider;
    private bool isDamaged;


    /// <summary>
    /// to modify 
    /// </summary>



    void Start()
    {
        currentHealth = (float)maxHealth;
        regenerationTime = startRegenerationTime;
        healthSlider.value = currentHealth * 100 / maxHealth;

    }


    void Update()
    {

        healthSlider.value = currentHealth * 100 / maxHealth;
        if (!isDamaged)
        {
            if (currentHealth < maxHealth)
            {
                TakeHealth(healthPerSecond);
            }
        }
        else
        {
            regenerationTime -= Time.deltaTime;
            if (regenerationTime <= 0)
            {
                isDamaged = false;
                regenerationTime = startRegenerationTime;
            }
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeHealth(float ammount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += ammount;
            healthSlider.value = currentHealth * 100 / maxHealth;
        }
    }
    public void TakeDamage(int damage)
    {
        isDamaged = true;
        regenerationTime = startRegenerationTime;
        if (currentHealth > 0F)
        {
            currentHealth -= damage;
            healthSlider.value = currentHealth * 100 / maxHealth;
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("Level_01");
    }


}
