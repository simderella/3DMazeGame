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
            UIManager.Instance.text.color = Color.black;
            UIManager.Instance.goodjob = "�����ϼ̽��ϴ�.";

            ending.SetActive(true);
            
            gameManager.Instance.goToStartScene = true;
        }
    }
}

