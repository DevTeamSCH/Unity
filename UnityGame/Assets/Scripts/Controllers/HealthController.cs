using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public HealthBar healthBar;
    void Start()
    {
        health = maxHealth;
        
    }
    public void TakeDamage(int amount)
    {
        if (amount > health) health = 0;
        else health -= amount;
        healthBar.SetPercent((float)health / maxHealth);
    }
    public void Heal(int amount)
    {
        if (health + amount > maxHealth) health = maxHealth;
        else health += amount;
        healthBar.SetPercent(health / maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
