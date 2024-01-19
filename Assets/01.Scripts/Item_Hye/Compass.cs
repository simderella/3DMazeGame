using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform playerTransform; //플레이어의 Transform을 연결.
    public Transform exitTransform; //출구의 Transform을 연결.
    public GameObject compassArrowPrefab;   //나침반 화살표 프리팹
    public LineRenderer lineRenderer;
    public bool useCompass;
    private float time;
    public float activeTime;


    private GameObject compassArrowInstance; //나침반 화살표 인스턴스

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("ItemHolder").transform;//ItemHolder라는 게임오브젝트를 찾아서 transform을 가져온다
        exitTransform = GameObject.Find("End").transform;//End라는 게임오브젝트를 찾아서 transform을 가져온다
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;//LineRenderer를 잇는 점의 개수
        lineRenderer.enabled = false;

        //나침반 화살표 인스턴스 생성
        //compassArrowInstance = Instantiate(compassArrowPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {   
        if (playerTransform != null && exitTransform != null)
        {
            if(useCompass)//CompassClass에서 useCompass가 true가 된다면
            {
                time += Time.deltaTime;//시간을 잰다
                if (time < activeTime)//시간이 ActiveTime을 넘지 못했다면
                {
                    lineRenderer.enabled = true;//LineRenderer를 켜고

                    lineRenderer.SetPosition(0, playerTransform.position);//LineRenderer의 첫번째 점의 위치는 playerTransform의 position이고
                    lineRenderer.SetPosition(1, exitTransform.position);//LineRenderer의 두번째 점의 위치는 exitTransform의 position이다
                }
                else
                {
                    Destroy(this.gameObject);//시간이 ActiveTime을 넘었다면 이 아이템을 파괴한다.
                }
            }

            else
            {
                lineRenderer.enabled=false;//평소에는 LineRenderer를 끈다.
            }
        }
    }
}
    


//    void Update()
//    {
//        if (playerTransform != null && exitTransform != null)
//        {
//            // 플레이어에서 출구까지의 방향을 구한다.
//            Vector3 directionToExit = exitTransform.position - playerTransform.position;

//            // 방향을 회전 각도로 변환한다.
//            float angle = Mathf.Atan2(directionToExit.x, directionToExit.z) * Mathf.Rad2Deg;

//            //transform.localPosition = new Vector3 (0, 0, 0);

//            // 나침반을 해당 각도로 회전시킨다.
//            transform.rotation = Quaternion.Euler(0f, angle + 45.0f, 0f);
//        }
//    }

//    //방향을 직접 업데이트하는 메서드
//    public void UpdateCompassDirection(Transform player, Transform exit)
//    {
//        playerTransform = player;
//        exitTransform = exit;

//        Update();
//    }
//}
