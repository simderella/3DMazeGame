using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToStart : MonoBehaviour
{
    public Transform startingPoint; // ���� ���� ����

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayerToStart(other.transform);
        }
    }

    void TeleportPlayerToStart(Transform playerTransform)
    {
        // �÷��̾� ��ġ�� ���� �������� �̵�
        playerTransform.position = startingPoint.position;
    }
}
