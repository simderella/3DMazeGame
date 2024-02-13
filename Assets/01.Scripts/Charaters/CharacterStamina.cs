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
    public float walkSpeed = 4f; // 걷는 속도
    public float runSpeed = 7f; // 달리는 속도

    public Image staminaImage;  // 연결할 UI Image 요소

    private bool isRunning = false;
    private PlayerController playerController;

    void Start()
    {
        currentStamina = maxStamina;
        playerController = GetComponent<PlayerController>();
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
        // 스태미나가 소진되면 걷기로 바뀜
        if (currentStamina <= 0)
        {
            isRunning = false;
            currentStamina = 0;
        }

        // 스태미나가 0이 되면 달리기 비활성화
        if (currentStamina == 0)
        {
            isRunning = false;
        }
        else
        {
            //걷는 중.
            isRunning = false;
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

        // isRunning 변수를 사용하여 캐릭터의 달리기 여부를 직접 제어
        if ((isRunning || Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed) && currentStamina > 0)
        {
            // 달리기 중의 이동 코드 추가
            //float speed = runSpeed;
            playerController.currentSpeed = runSpeed;

            // 스태미나 감소
            currentStamina -= staminaDecreaseRate * Time.deltaTime;

            // 스태미나가 0이 되면 무조건 걷기로 전환
            if (currentStamina <= 0)
            {
                isRunning = false;
            }
        }
        else
        {
            // 걷기 중의 이동 코드 추가
            playerController.currentSpeed = walkSpeed;

            // 스태미나 회복
            currentStamina += staminaRecoveryRate * Time.deltaTime;

            // 스태미나가 0이 되면 무조건 걷기로 전환
            if (currentStamina <= 0)
            {
                isRunning = false;
            }
            else
            {
                // 이동
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed)
                {
                    // 달리기 버튼이 눌렸을 때만 달리기
                    isRunning = currentStamina > 0;
                    //transform.Translate(Vector3.forward * (isRunning ? runSpeed : speed) * Time.deltaTime);
                }
                else
                {
                    // 아무 키도 안 누를 때는 정지
                    transform.Translate(Vector3.zero);
                }
            }
        }

    }
    public void ApplySpeedPotion(float speedBoostAmount, float duration)
    {
        // 현재 속도에만 영향을 주도록 수정
        walkSpeed += speedBoostAmount;
        runSpeed += speedBoostAmount;

        StartCoroutine(RemoveSpeedBoostAfterDuration(speedBoostAmount, duration));
    }
    private IEnumerator RemoveSpeedBoostAfterDuration(float speedBoostAmount, float duration)
    {
        yield return new WaitForSeconds(duration);

        // 현재 속도를 원래 값으로 되돌림
        walkSpeed -= speedBoostAmount;
        runSpeed -= speedBoostAmount;
        Debug.Log("이동 속도가 원래대로 돌아갔다!");
    }
}