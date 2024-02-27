using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassEnegyBall : MonoBehaviour
{
    public Transform playerTransform; //�÷��̾��� Transform�� ����.
    public MagicSwitch[] magicswitch; //�ⱸ�� Transform�� ����.
    public GameObject compassArrowPrefab;   //��ħ�� ȭ��ǥ ������
    public LineRenderer lineRenderer;
    public bool useCompass;
    private float time;
    public float activeTime;
    public bool activatingCompass;


    private GameObject compassArrowInstance; //��ħ�� ȭ��ǥ �ν��Ͻ�

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("ItemHolder").transform;//ItemHolder��� ���ӿ�����Ʈ�� ã�Ƽ� transform�� �����´�
        magicswitch = GameObject.FindObjectsOfType<MagicSwitch>();//End��� ���ӿ�����Ʈ�� ã�Ƽ� transform�� �����´�
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;//LineRenderer�� �մ� ���� ����
        lineRenderer.enabled = false;

        //��ħ�� ȭ��ǥ �ν��Ͻ� ����
        //compassArrowInstance = Instantiate(compassArrowPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            if (useCompass)//CompassClass���� useCompass�� true�� �ȴٸ�
            {
                time += Time.deltaTime;//�ð��� ���
                if (time < activeTime)//�ð��� ActiveTime�� ���� ���ߴٸ�
                {
                    if(magicswitch.Length > 0)
                    {
                        if (magicswitch[0] != null)
                        {
                            lineRenderer.enabled = true;//LineRenderer�� �Ѱ�
                            activatingCompass = true;
                            lineRenderer.SetPosition(0, playerTransform.position);//LineRenderer�� ù��° ���� ��ġ�� playerTransform�� position�̰�
                            lineRenderer.SetPosition(1, magicswitch[0].transform.position);//LineRenderer�� �ι�° ���� ��ġ�� exitTransform�� position�̴�
                        }
                        else if (magicswitch[1] != null)
                        {
                            lineRenderer.enabled = true;//LineRenderer�� �Ѱ�
                            activatingCompass = true;
                            lineRenderer.SetPosition(0, playerTransform.position);//LineRenderer�� ù��° ���� ��ġ�� playerTransform�� position�̰�
                            lineRenderer.SetPosition(1, magicswitch[1].transform.position);//LineRenderer�� �ι�° ���� ��ġ�� exitTransform�� position�̴�
                        }
                        else if (magicswitch[2] != null)
                        {
                            lineRenderer.enabled = true;//LineRenderer�� �Ѱ�
                            activatingCompass = true;
                            lineRenderer.SetPosition(0, playerTransform.position);//LineRenderer�� ù��° ���� ��ġ�� playerTransform�� position�̰�
                            lineRenderer.SetPosition(1, magicswitch[2].transform.position);//LineRenderer�� �ι�° ���� ��ġ�� exitTransform�� position�̴�
                        }
                    }
                    else
                    {
                        UIManager.Instance.description.text = "���̻� ���� ���������� �����ϴ�.";
                    }
                }
                else
                {
                    activatingCompass = false;
                    Destroy(this.gameObject);//�ð��� ActiveTime�� �Ѿ��ٸ� �� �������� �ı��Ѵ�.
                }
            }

            else
            {
                lineRenderer.enabled = false;//��ҿ��� LineRenderer�� ����.
            }
        }
    }
}




