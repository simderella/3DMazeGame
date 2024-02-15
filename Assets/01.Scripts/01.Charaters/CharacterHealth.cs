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


    [SerializeField] private Image healthBarImage; // 이미지 컴포넌트를 저장할 변수
    public bool IsDead => health == 0;

    private void Start()
    {
        health = maxHealth;

        // Start 메서드에서 이미지 컴포넌트를 초기화합니다.
        if (healthBarImage == null)
        {
            healthBarImage = GetComponentInChildren<Image>(); // 이미지 컴포넌트가 자식 객체에 있는 경우를 가정하고 가져옵니다.
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
        // healthBarImage가 null이 아니라면 (정상적으로 참조되었다면)
        if (healthBarImage != null)
        {
            // health를 0에서 1 사이의 값으로 정규화하여 fillAmount에 적용
            healthBarImage.fillAmount = (float)health / maxHealth;
        }
    }
}