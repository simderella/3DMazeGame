using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomPositionSetter : MonoBehaviour
{
    public Transform[] spawnPoints; // 미리 정의된 4가지 위치
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
