using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagicPortal : MonoBehaviour
{
    public GameObject ending;
    private float time;
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {
            UIManager.Instance.textinstage5.color = Color.black;
            UIManager.Instance.goodjob = "수고하셨습니다.";

            ending.SetActive(true);
            
            gameManager.Instance.goToStartScene = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

