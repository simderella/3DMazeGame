using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{

    public GameObject pathPrefab; //��θ� ��Ÿ�� ������
    private List<Vector3> pathPoints = new List<Vector3>();
    private GameObject pathObject;  //��θ� �׸� ������Ʈ
    private bool hasItem = false;   //�������� ���ϰ� �ִ���.
    private string acquiredItemName;  // ȹ���� �������� �̸�



    // Start is called before the first frame update
    void Start()
    {
        //��θ� �׸� ������Ʈ ����
        pathObject = Instantiate(pathPrefab, Vector3.zero, Quaternion.identity);
        pathObject.SetActive(false); //�ʱ⿡�� ��θ� ǥ������ ����
    }


    // Update is called once per frame
    void Update()
    {
        //�÷��̾� �̵� ó��
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * 5f);

        //�÷��̾��� ���� ��ġ�� ��ο� �߰�
        pathPoints.Add(transform.position);

        //��θ� ǥ���ϴ� �� �׸���
        DrawPath();
    }

  

    private void DrawPath()
    {
        if(hasItem)
        {
            // Line Renderer ������Ʈ ��������
            LineRenderer lineRenderer = pathObject.GetComponent<LineRenderer>();

            //����� ��ǥ�� Line Renderer�� ����
            lineRenderer.positionCount = pathPoints.Count;
            lineRenderer.SetPositions(pathPoints.ToArray());
        }
    }

    //�������� ŉ���� �� ȣ��Ǵ�
    public void AcquireItem(string itemName)
    {
        if (!hasItem)
        {
            // Ư�� �������� ȹ���ϸ� ��θ� ǥ���ϵ��� ����
            if (itemName == "SpecialItem")
            {
                hasItem = true;
                acquiredItemName = itemName;
                TogglePathDisplay();
            }
        }
    }

    //��� ǥ�� Ȱ��ȭ/��Ȱ��ȭ
    private void TogglePathDisplay()
    {
        pathObject.SetActive(hasItem);
    }
}
