using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform playerTransform; //�÷��̾��� Transform�� ����.
    public Transform exitTransform; //�ⱸ�� Transform�� ����.
    public GameObject compassArrowPrefab;   //��ħ�� ȭ��ǥ ������

    private GameObject compassArrowInstance; //��ħ�� ȭ��ǥ �ν��Ͻ�

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        exitTransform = GameObject.Find("End").transform;
        //��ħ�� ȭ��ǥ �ν��Ͻ� ����
        //compassArrowInstance = Instantiate(compassArrowPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null && exitTransform != null)
        {
            // �÷��̾�� �ⱸ������ ������ ���Ѵ�.
            Vector3 directionToExit = exitTransform.position - playerTransform.position;

            // ������ ȸ�� ������ ��ȯ�Ѵ�.
            float angle = Mathf.Atan2(directionToExit.x, directionToExit.z) * Mathf.Rad2Deg;

            //transform.localPosition = new Vector3 (0, 0, 0);

            // ��ħ���� �ش� ������ ȸ����Ų��.
            transform.rotation = Quaternion.Euler(0f, angle + 45.0f, 0f);
        }
    }

    //������ ���� ������Ʈ�ϴ� �޼���
    public void UpdateCompassDirection(Transform player, Transform exit)
    {
        playerTransform = player;
        exitTransform = exit;

        Update();
    }
}
