using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPortal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {
            UIManager.Instance.text.color = Color.black;
            UIManager.Instance.goodjob = "�����ϼ̽��ϴ�.";
            ;

        }
    }
}

