using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform playerTransform; //플레이어의 Transform을 연결.
    public Transform exitTransform; //출구의 Transform을 연결.
    public GameObject compassArrowPrefab;   //나침반 화살표 프리팹

    private GameObject compassArrowInstance; //나침반 화살표 인스턴스

    // Start is called before the first frame update
    void Start()
    {
        //나침반 화살표 인스턴스 생성
        compassArrowInstance = Instantiate(compassArrowPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null && exitTransform != null)
        {
            // 플레이어에서 출구까지의 방향을 구한다.
            Vector3 directionToExit = exitTransform.position - playerTransform.position;

            // 방향을 회전 각도로 변환한다.
            float angle = Mathf.Atan2(directionToExit.x, directionToExit.z) * Mathf.Rad2Deg;

            // 나침반을 해당 각도로 회전시킨다.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    //방향을 직접 업데이트하는 메서드


    public void UpdateCompassDirection(Transform player, Transform exit)
    {
        playerTransform = player;
        exitTransform = exit;

        Update();
    }
}
