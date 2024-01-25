using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaDecreaseRate = 20f;  // �޸���� ���� ���¹̳� ���� �ӵ�
    public float staminaRecoveryRate = 10f; // ��޸��� ���¿����� ���¹̳� ȸ�� �ӵ�
    public float walkSpeed = 2f; // �ȴ� �ӵ�
    public float runSpeed = 5f; // �޸��� �ӵ�

    public Image staminaImage;  // ������ UI Image ���

    private bool isRunning = false;

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    void Update()
    {
        // �޸��� ���̸� ���¹̳� ����
        // �޸��� ���� �ƴϸ� ���¹̳� ȸ��
        if ((Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed) && currentStamina > 0)
        {
            //�޸��� ��.
            isRunning = true;
            currentStamina -= staminaDecreaseRate * Time.deltaTime;
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

        // isRunning ������ ����Ͽ� ĳ������ �޸��� ���θ� ���� ����
        if ((isRunning || Input.GetKey(KeyCode.LeftShift) || Mouse.current.rightButton.isPressed) && currentStamina > 0)
        {
            // �޸��� ���� �̵� �ڵ� �߰�
            float speed = runSpeed;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // ���¹̳� ����
            currentStamina -= staminaDecreaseRate * Time.deltaTime;

            // ���¹̳��� 0�� �Ǹ� ������ �ȱ�� ��ȯ
            if (currentStamina <= 0)
            {
                isRunning = false;
            }
        }
        else
        {
            // �ȱ� ���� �̵� �ڵ� �߰�
            float speed = walkSpeed;

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
                    transform.Translate(Vector3.forward * (isRunning ? runSpeed : speed) * Time.deltaTime);
                }
                else
                {
                    // �ƹ� Ű�� �� ���� ���� ����
                    transform.Translate(Vector3.zero);
                }
            }
        }
    }
}