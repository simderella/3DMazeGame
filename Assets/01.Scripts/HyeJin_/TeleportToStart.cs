using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToStart : MonoBehaviour
{
    public Transform startingPoint; // 시작 지점 설정

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayerToStart(other.transform);
        }
    }

    void TeleportPlayerToStart(Transform playerTransform)
    {
        // 플레이어 위치를 시작 지점으로 이동
        playerTransform.position = startingPoint.position;
    }
}
