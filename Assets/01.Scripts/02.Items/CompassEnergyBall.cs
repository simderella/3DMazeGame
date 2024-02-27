using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassEnegyBall : MonoBehaviour
{
    public Transform playerTransform; //플레이어의 Transform을 연결.
    public MagicSwitch[] magicswitch; //출구의 Transform을 연결.
    public GameObject compassArrowPrefab;   //나침반 화살표 프리팹
    public LineRenderer lineRenderer;
    public bool useCompass;
    private float time;
    public float activeTime;
    public bool activatingCompass;


    private GameObject compassArrowInstance; //나침반 화살표 인스턴스

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("ItemHolder").transform;//ItemHolder라는 게임오브젝트를 찾아서 transform을 가져온다
        magicswitch = GameObject.FindObjectsOfType<MagicSwitch>();//End라는 게임오브젝트를 찾아서 transform을 가져온다
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;//LineRenderer를 잇는 점의 개수
        lineRenderer.enabled = false;

        //나침반 화살표 인스턴스 생성
        //compassArrowInstance = Instantiate(compassArrowPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            if (useCompass)//CompassClass에서 useCompass가 true가 된다면
            {
                time += Time.deltaTime;//시간을 잰다
                if (time < activeTime)//시간이 ActiveTime을 넘지 못했다면
                {
                    if(magicswitch.Length > 0)
                    {
                        if (magicswitch[0] != null)
                        {
                            lineRenderer.enabled = true;//LineRenderer를 켜고
                            activatingCompass = true;
                            lineRenderer.SetPosition(0, playerTransform.position);//LineRenderer의 첫번째 점의 위치는 playerTransform의 position이고
                            lineRenderer.SetPosition(1, magicswitch[0].transform.position);//LineRenderer의 두번째 점의 위치는 exitTransform의 position이다
                        }
                        else if (magicswitch[1] != null)
                        {
                            lineRenderer.enabled = true;//LineRenderer를 켜고
                            activatingCompass = true;
                            lineRenderer.SetPosition(0, playerTransform.position);//LineRenderer의 첫번째 점의 위치는 playerTransform의 position이고
                            lineRenderer.SetPosition(1, magicswitch[1].transform.position);//LineRenderer의 두번째 점의 위치는 exitTransform의 position이다
                        }
                        else if (magicswitch[2] != null)
                        {
                            lineRenderer.enabled = true;//LineRenderer를 켜고
                            activatingCompass = true;
                            lineRenderer.SetPosition(0, playerTransform.position);//LineRenderer의 첫번째 점의 위치는 playerTransform의 position이고
                            lineRenderer.SetPosition(1, magicswitch[2].transform.position);//LineRenderer의 두번째 점의 위치는 exitTransform의 position이다
                        }
                    }
                    else
                    {
                        UIManager.Instance.description.text = "더이상 남은 에너지볼이 없습니다.";
                    }
                }
                else
                {
                    activatingCompass = false;
                    Destroy(this.gameObject);//시간이 ActiveTime을 넘었다면 이 아이템을 파괴한다.
                }
            }

            else
            {
                lineRenderer.enabled = false;//평소에는 LineRenderer를 끈다.
            }
        }
    }
}




