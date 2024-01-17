using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathItem : MonoBehaviour
{
    public string itemName = "SpecialItem";  // 아이템의 이름

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PathController pathController = other.GetComponent<PathController>();
            if (pathController != null)
            {
                // 아이템의 이름을 전달하여 획득 여부를 처리
                pathController.AcquireItem(itemName);
            }

            // 아이템 비활성화 또는 삭제 등의 추가 동작 수행
            gameObject.SetActive(false);
        }
    }
}
