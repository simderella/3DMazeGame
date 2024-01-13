using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPortal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {
            UIManager.Instance.text.color = Color.white;
            UIManager.Instance.goodjob = "수고하셨습니다.";
            Debug.Log("다음 스테이지로 이동합니다.");
            ;

        }

    }

}

