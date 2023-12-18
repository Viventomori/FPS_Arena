using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class HealthSystem : MonoBehaviour
{
    public int health;
    public int healthMax;

    public IHealthBar healthBar;

    private void Awake()
    {
        healthBar.SetMaxHealth(healthMax);
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.SetHealth(health);
        if (health <= 0)
        {
            gameObject.SetActive(false);
            //GameController.instance.StopGame(0);
            //GameController.instance.DeadPlayer();
        }
    }

    public void AddHealth (int amount)
    {
        health += amount;
        if (health >= 100)
        {
            health = 100;
        }
        healthBar.SetHealth(health);
    }
}