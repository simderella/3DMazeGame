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

    public Image staminaImage;  // ������ UI Image ���

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
            currentStamina -= staminaDecreaseRate * Time.deltaTime;
        }
        else
        {
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
    }

}
