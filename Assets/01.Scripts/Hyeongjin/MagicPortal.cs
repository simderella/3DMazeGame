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
            UIManager.Instance.text.text = "포탈이 활성화되었습니다.";
            Debug.Log("다음 스테이지로 이동합니다.");
            ;

        }

    }

}

