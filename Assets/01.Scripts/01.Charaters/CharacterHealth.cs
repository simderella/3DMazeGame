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
    public event Action PlayerDie;


    [SerializeField] private Image healthBarImage; // �̹��� ������Ʈ�� ������ ����
    public bool IsDead => health == 0;

    private void Start()
    {
        health = maxHealth;

        // Start �޼��忡�� �̹��� ������Ʈ�� �ʱ�ȭ�մϴ�.
        if (healthBarImage == null)
        {
            healthBarImage = GetComponentInChildren<Image>(); // �̹��� ������Ʈ�� �ڽ� ��ü�� �ִ� ��츦 �����ϰ� �����ɴϴ�.
        }

        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;
        health = Mathf.Max(health - damage, 0);
        UpdateHealthBar();
        if (health == 0)
        {
            OnDie?.Invoke();
            PlayerDie?.Invoke();
        }



    }

    public void PotionHeal(int potion)
    {
        health += potion;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }

        UpdateHealthBar();
    }



    

    private void UpdateHealthBar()
    {
        // healthBarImage�� null�� �ƴ϶�� (���������� �����Ǿ��ٸ�)
        if (healthBarImage != null)
        {
            // health�� 0���� 1 ������ ������ ����ȭ�Ͽ� fillAmount�� ����
            healthBarImage.fillAmount = (float)health / maxHealth;
        }
    }
}