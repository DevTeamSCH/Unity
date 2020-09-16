using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class HealthController : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public HealthBar healthBar;
    
    public Text hpText;
    private bool _hpChanged = false;
    
    //booster functions
    public void ApplyHpBooster(int value){
        _hpChanged = true;
        health += value;
        maxHealth += value;
    }

    public void DenyHpBooster(int value){
        _hpChanged = true;
        maxHealth -= value;
        
        if (health > maxHealth)
            health = maxHealth;
        
    }
    //Booster function ends

    void Start()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(int amount){
        _hpChanged = true;
        
        if (amount > health)
        {
            health = 0;
        }
        else health -= amount;
        healthBar.SetPercent((float)health / maxHealth);
    }
    public void Heal(int amount)
    {
        _hpChanged = true;
        
        if (health + amount > maxHealth) health = maxHealth;
        else health += amount;
        healthBar.SetPercent(health / maxHealth);
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }

    void Update(){

        if(health == 0)
            Die();
        
        if (_hpChanged && hpText){
            hpText.text = health.ToString() + "/" + maxHealth.ToString();
            _hpChanged = false;
        }
    }
}
