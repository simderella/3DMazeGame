using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDecreaseRate = 20f;  // 달리기로 인한 스태미나 감소 속도
    public float staminaRecoveryRate = 10f; // 비달리기 상태에서의 스태미나 회복 속도

    public Image staminaImage;  // 연결할 UI Image 요소

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    void Update()
    {
        // 달리기 중이면 스태미나 감소
        // 달리기 중이 아니면 스태미나 회복
        if ((Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed) && currentStamina > 0)
        {
            currentStamina -= staminaDecreaseRate * Time.deltaTime;
        }
        else
        {
            currentStamina += staminaRecoveryRate * Time.deltaTime;
        }

        // 스태미나가 음수로 떨어지지 않도록 보정
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        // UI에 스태미나 표시
        UpdateStaminaUI();
    }

    void UpdateStaminaUI()
    {
        // UI Image 요소의 fillAmount 속성을 조절하여 스태미나 표시
        staminaImage.fillAmount = currentStamina / maxStamina;
    }

}
