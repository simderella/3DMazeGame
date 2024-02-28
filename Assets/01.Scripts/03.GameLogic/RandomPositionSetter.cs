using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomPositionSetter : MonoBehaviour
{
    public Transform[] spawnPoints; // �̸� ���ǵ� 4���� ��ġ
    void Start()
    {
        SetRandomPosition();
    }

    void SetRandomPosition()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        transform.position = selectedSpawnPoint.position;
    }
}
