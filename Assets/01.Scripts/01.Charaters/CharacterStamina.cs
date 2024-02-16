using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDecreaseRate = 10f;  // �޸���� ���� ���¹̳� ���� �ӵ�
    public float staminaRecoveryRate = 10f; // ��޸��� ���¿����� ���¹̳� ȸ�� �ӵ�
    public float walkSpeed = 5f; // �ȴ� �ӵ�
    public float runSpeed = 8f; // �޸��� �ӵ�
    public bool boostOn;

    public Image staminaImage;  // ������ UI Image ���

    private bool isRunning = false;
    private bool isFootstepPlaying = false; // �ȴ� �Ҹ� ��� ���θ� �����ϱ� ���� ���� �߰�
    private bool isRunningPlaying = false; // �޸��� �Ҹ� ��� ���θ� �����ϱ� ���� ���� �߰�
    private PlayerController playerController;

    private SoundManager soundManager; // ���� ���� ���� �߰�

    void Start()
    {
        currentStamina = maxStamina;
        playerController = GetComponent<PlayerController>();
        soundManager = SoundManager.Instance; // SoundManager �ν��Ͻ� ��������
        UpdateStaminaUI();
    }

    void Update()
    {
        bool isRunningButtonPressed = Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed;

        // �޸��� ���̸� ���¹̳� ����
        // �޸��� ���� �ƴϸ� ���¹̳� ȸ��
        if ((Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed) && currentStamina > 0)
        {
            //�޸��� ��.
            isRunning = true;
            currentStamina -= staminaDecreaseRate * Time.deltaTime;

            //�޸��� �Ҹ� ���
            if (!isRunningPlaying)
            {
                soundManager.PlaySFX("RunningSound");
                isRunningPlaying = true;
            }

            //soundManager.PlaySFX("RunningSound");   // �޸��� ���� �� �Ҹ� ���
        }
        else
        {
            isRunning = false;
            currentStamina += staminaRecoveryRate * Time.deltaTime;

            // ������ ���콺 ��ư�� �� ��
            if (currentStamina <= 0 && isRunningPlaying || !isRunningButtonPressed && isRunningPlaying)
            {
                soundManager.StopRunningSFX(); // �޸��� �Ҹ� ����
                soundManager.PlaySFX("FootstepSound"); // �ȴ� �Ҹ��� ����
                isRunningPlaying = false;
            }
        }


        // ���¹̳��� �����Ǹ� �ȱ�� �ٲ�
        if (currentStamina <= 0)
        {
            isRunning = false;
            currentStamina = 0;
        }

        // ���¹̳��� 0�� �Ǹ� �޸��� ��Ȱ��ȭ
        if (currentStamina == 0)
        {
            isRunning = false;
        }
        else
        {
            //�ȴ� ��.
            isRunning = false;
            currentStamina += staminaRecoveryRate * Time.deltaTime;
        }

        // ���¹̳��� ������ �������� �ʵ��� ����
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        // UI�� ���¹̳� ǥ��
        UpdateStaminaUI();


    }

    void UpdateStaminaUI()
    {
        // UI Image ����� fillAmount �Ӽ��� �����Ͽ� ���¹̳� ǥ��
        staminaImage.fillAmount = currentStamina / maxStamina;


        if (isRunning && currentStamina > 0)
        {
            playerController.currentSpeed = runSpeed;
        }
        else
        {
            playerController.currentSpeed = walkSpeed;
        }


        // isRunning ������ ����Ͽ� ĳ������ �޸��� ���θ� ���� ����
        if ((isRunning || Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed) && currentStamina > 0)
        {
            // �޸��� ���� �̵� �ڵ� �߰�
            //float speed = runSpeed;
            playerController.currentSpeed = runSpeed;

            // ���¹̳� ����
            currentStamina -= staminaDecreaseRate * Time.deltaTime;

            if (!isRunningPlaying) // �޸��� �Ҹ� ��� ���� 
            {
                soundManager.PlaySFX("RunningSound");
                isRunningPlaying = true;
            }

            


            // ���¹̳��� 0�� �Ǹ� ������ �ȱ�� ��ȯ
            if (currentStamina <= 0)
            {

                isRunning = false;
            }
        }
        else
        {
            // �ȱ� ���� �̵� �ڵ� �߰�
            playerController.currentSpeed = walkSpeed;

            // ���¹̳� ȸ��
            currentStamina += staminaRecoveryRate * Time.deltaTime;

            // ���¹̳��� 0�� �Ǹ� ������ �ȱ�� ��ȯ
            if (currentStamina <= 0)
            {
                isRunning = false;
            }
            else
            {
                // �̵�
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed)
                {
                    // �޸��� ��ư�� ������ ���� �޸���
                    isRunning = currentStamina > 0;
                    //transform.Translate(Vector3.forward * (isRunning ? runSpeed : speed) * Time.deltaTime);
                }
                else
                {
                    // �ƹ� Ű�� �� ���� ���� ����
                    transform.Translate(Vector3.zero);
                }
            }
        }

    }
    public void ApplySpeedPotion(float speedBoostAmount, float duration)
    {
        // ���� �ӵ����� ������ �ֵ��� ����
        walkSpeed += speedBoostAmount;
        runSpeed += speedBoostAmount;
        boostOn = true;

        StartCoroutine(RemoveSpeedBoostAfterDuration(speedBoostAmount, duration));
    }
    private IEnumerator RemoveSpeedBoostAfterDuration(float speedBoostAmount, float duration)
    {
        yield return new WaitForSeconds(duration);

        // ���� �ӵ��� ���� ������ �ǵ���
        walkSpeed -= speedBoostAmount;
        runSpeed -= speedBoostAmount;
        boostOn = false;
        Debug.Log("�̵� �ӵ��� ������� ���ư���!");
    }
}