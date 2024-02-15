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
            // �÷��̾ ������ ��ǥ ��ġ�� �̵���Ű�� �Լ� ȣ��
            MovePlayerToTargetPosition(other.gameObject);
        }
    }

    // �÷��̾ ������ ��ǥ ��ġ�� �̵���Ű�� �Լ�
    private void MovePlayerToTargetPosition(GameObject player)
    {
        // ��ǥ ��ġ�� �����Ǿ� �ִ��� Ȯ��
        if (targetPosition != null)
        {
            // �÷��̾��� ��ġ�� ������ ��ǥ ��ġ�� ����
            player.transform.position = targetPosition.position;
            // ����� �α� ���
            Debug.Log("Player moved to target position.");
        }
        else
        {
            // ��ǥ ��ġ�� �����Ǿ� ���� ������ ���� �α� ���
            Debug.LogError("Target position is not assigned in the Inspector.");
        }
    }
}
