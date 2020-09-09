using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    private int _originalMax;
    public HealthBar healthBar;
    
    public Text hpText;
    private bool _hpChanged = false;
    
    //booster functions + variables
    private List<HpBoost> _hpBoosts = new List<HpBoost>();
    public Text boosterText;
    
    public void BoostHp(int value, float duration){
        _hpChanged = true;
        _hpBoosts.Add(new HpBoost(duration, value));
        health += value;
        maxHealth += value;
    }
    
    
    void Start()
    {
        health = maxHealth;
        _originalMax = maxHealth;
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
        string boosters = "";
        
        List<HpBoost> dels = new List<HpBoost>();
        foreach (var hpBoost in _hpBoosts){
            if (hpBoost.Refresh()){
                maxHealth -= hpBoost.value;
                if (health > maxHealth)
                    health = maxHealth;
                dels.Add(hpBoost);
                _hpChanged = true;
            }
            boosters += hpBoost.type + ":" + hpBoost.Write() + "\n";
        }

        if (boosterText){
            boosterText.text = boosters;
        }
        
        foreach (var hpBoost in dels){
            _hpBoosts.Remove(hpBoost);
        }
        
        if(health == 0)
            Die();
        
        if (_hpChanged && hpText){
            hpText.text = health.ToString() + "/" + maxHealth.ToString();
            _hpChanged = false;
        }
    }
}
