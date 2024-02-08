using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject popupUI;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (popupUI.activeSelf)
            {
                ClosePopup();
            }
            else
            {
                OpenPopup();
            }

            // P 버튼을 누를 때 효과음 재생
            SoundManager.Instance.PlaySFX("PopupSound");
        }
    }

    void OpenPopup()
    {
        popupUI.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ClosePopup()
    {
        popupUI.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
