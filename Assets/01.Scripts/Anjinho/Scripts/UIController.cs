using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public GameObject popupUI;

    void Update()
    {
        // Esc 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.P))
        {
            // 팝업이 현재 활성화되어 있지 않으면 활성화, 이미 활성화되어 있으면 비활성화
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
        // 팝업이 열릴 때 추가적인 작업 수행
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ClosePopup()
    {
        popupUI.SetActive(false);
        // 팝업이 닫힐 때 추가적인 작업 수행
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
