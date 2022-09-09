using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrHealth;
    public HealthBar healthbar;

    void Start()
    {
        CurrHealth = MaxHealth;
        healthbar.setMaxHealth(MaxHealth);
    }
    void Update()
    {
        if (CurrHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        CurrHealth -= damage;
        healthbar.setHealth(CurrHealth);
    }
}

