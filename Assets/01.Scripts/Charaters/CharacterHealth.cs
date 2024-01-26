using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float health;
    public event Action OnDie;
    public Image healthbar;

    public bool IsDead => health == 0;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;
        health = Mathf.Max(health - damage, 0);

        if (health == 0)
            OnDie?.Invoke();

        Debug.Log(health);
        healthbar.fillAmount = GetPercentage();
        Debug.Log(GetPercentage());
    }

    public void PotionHeal(int potion)
    {
        health += potion;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }

        healthbar.fillAmount = GetPercentage();

    }

    public float GetPercentage()
    {
        return health / maxHealth;
    }

    
}