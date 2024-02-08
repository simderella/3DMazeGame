using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject popupUI;

    private AudioSource audioSource;
    public AudioClip Openclip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
                audioSource.clip = Openclip;
                audioSource.Play();
            }
        }
    }

    void OpenPopup()
    {
        popupUI.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerController.instance.canLook = false;
    }

    void ClosePopup()
    {
        popupUI.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerController.instance.canLook = true;
    }
}
