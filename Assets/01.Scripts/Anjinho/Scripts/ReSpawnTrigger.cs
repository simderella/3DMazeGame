using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnTrigger : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어를 지정된 목표 위치로 이동시키는 함수 호출
            MovePlayerToTargetPosition(other.gameObject);
        }
    }

    // 플레이어를 지정된 목표 위치로 이동시키는 함수
    private void MovePlayerToTargetPosition(GameObject player)
    {
        // 목표 위치가 지정되어 있는지 확인
        if (targetPosition != null)
        {
            // 플레이어의 위치를 지정된 목표 위치로 설정
            player.transform.position = targetPosition.position;
            // 디버그 로그 출력
            Debug.Log("Player moved to target position.");
        }
        else
        {
            // 목표 위치가 지정되어 있지 않으면 에러 로그 출력
            Debug.LogError("Target position is not assigned in the Inspector.");
        }
    }
}
