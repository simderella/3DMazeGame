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
    public float walkSpeed = 2f; // 걷는 속도
    public float runSpeed = 5f; // 달리는 속도

    public Image staminaImage;  // 연결할 UI Image 요소

    private bool isRunning = false;
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    void Update()
    {
        // 달리기 중이면 스태미나 감소
        // 달리기 중이 아니면 스태미나 회복
        if ((Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed) && currentStamina > 0)
        {
            //달리는 중.
            isRunning = true;
            currentStamina -= staminaDecreaseRate * Time.deltaTime;
        }
        else
        {
            //걷는 중.
            isRunning = false;
            currentStamina += staminaRecoveryRate * Time.deltaTime;
        }

        //스태미나가 소진되면 걷기로 바뀜
        if(currentStamina <=0)
        {
            isRunning=false;
            currentStamina = 0;
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
