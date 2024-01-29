using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform playerTransform; //�÷��̾��� Transform�� ����.
    public Transform exitTransform; //�ⱸ�� Transform�� ����.
    public GameObject compassArrowPrefab;   //��ħ�� ȭ��ǥ ������
    public LineRenderer lineRenderer;
    public bool useCompass;
    private float time;
    public float activeTime;


    private GameObject compassArrowInstance; //��ħ�� ȭ��ǥ �ν��Ͻ�

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("ItemHolder").transform;//ItemHolder��� ���ӿ�����Ʈ�� ã�Ƽ� transform�� �����´�
        exitTransform = GameObject.Find("End").transform;//End��� ���ӿ�����Ʈ�� ã�Ƽ� transform�� �����´�
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;//LineRenderer�� �մ� ���� ����
        lineRenderer.enabled = false;

        //��ħ�� ȭ��ǥ �ν��Ͻ� ����
        //compassArrowInstance = Instantiate(compassArrowPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {   
        if (playerTransform != null && exitTransform != null)
        {
            if(useCompass)//CompassClass���� useCompass�� true�� �ȴٸ�
            {
                time += Time.deltaTime;//�ð��� ���
                if (time < activeTime)//�ð��� ActiveTime�� ���� ���ߴٸ�
                {
                    lineRenderer.enabled = true;//LineRenderer�� �Ѱ�

                    lineRenderer.SetPosition(0, playerTransform.position);//LineRenderer�� ù��° ���� ��ġ�� playerTransform�� position�̰�
                    lineRenderer.SetPosition(1, exitTransform.position);//LineRenderer�� �ι�° ���� ��ġ�� exitTransform�� position�̴�
                }
                else
                {
                    Destroy(this.gameObject);//�ð��� ActiveTime�� �Ѿ��ٸ� �� �������� �ı��Ѵ�.
                }
            }

            else
            {
                lineRenderer.enabled=false;//��ҿ��� LineRenderer�� ����.
            }
        }
    }
}
    


//    void Update()
//    {
//        if (playerTransform != null && exitTransform != null)
//        {
//            // �÷��̾�� �ⱸ������ ������ ���Ѵ�.
//            Vector3 directionToExit = exitTransform.position - playerTransform.position;

//            // ������ ȸ�� ������ ��ȯ�Ѵ�.
//            float angle = Mathf.Atan2(directionToExit.x, directionToExit.z) * Mathf.Rad2Deg;

//            //transform.localPosition = new Vector3 (0, 0, 0);

//            // ��ħ���� �ش� ������ ȸ����Ų��.
//            transform.rotation = Quaternion.Euler(0f, angle + 45.0f, 0f);
//        }
//    }

//    //������ ���� ������Ʈ�ϴ� �޼���
//    public void UpdateCompassDirection(Transform player, Transform exit)
//    {
//        playerTransform = player;
//        exitTransform = exit;

//        Update();
//    }
//}
