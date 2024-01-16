using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public GameObject popupUI;

    void Update()
    {
        // Esc Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.P))
        {
            // �˾��� ���� Ȱ��ȭ�Ǿ� ���� ������ Ȱ��ȭ, �̹� Ȱ��ȭ�Ǿ� ������ ��Ȱ��ȭ
            if (popupUI.activeSelf)
            {
                ClosePopup();
            }
            else
            {
                OpenPopup();
            }
        }

        
    }

    void OpenPopup()
    {
        popupUI.SetActive(true);
        // �˾��� ���� �� �߰����� �۾� ����
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ClosePopup()
    {
        popupUI.SetActive(false);
        // �˾��� ���� �� �߰����� �۾� ����
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
