using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class MagicPortalStage5 : MonoBehaviour
{
    public GameObject ending;
    private float time;
    public AudioSource bgm;
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {
            UIManager.Instance.textinstage5.color = Color.black;
            UIManager.Instance.goodjob = "수고하셨습니다.";
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            bgm.Stop();
            ending.SetActive(true);

            gameManager.Instance.goToStartScene = true;
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
        }
    }
}

