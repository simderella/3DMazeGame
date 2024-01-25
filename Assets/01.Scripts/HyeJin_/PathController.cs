using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{

    public GameObject pathPrefab; //경로를 나타낼 프리랩
    private List<Vector3> pathPoints = new List<Vector3>();
    private GameObject pathObject;  //경로를 그릴 오브젝트
    private bool hasItem = false;   //아이템을 지니고 있는지.
    private string acquiredItemName;  // 획득한 아이템의 이름



    // Start is called before the first frame update
    void Start()
    {
        //경로를 그릴 오브젝트 생성
        pathObject = Instantiate(pathPrefab, Vector3.zero, Quaternion.identity);
        pathObject.SetActive(false); //초기에는 경로를 표시하지 않음
    }


    // Update is called once per frame
    void Update()
    {
        //플레이어 이동 처리
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * 5f);

        //플레이어의 현재 위치를 경로에 추가
        pathPoints.Add(transform.position);

        //경로를 표시하는 선 그리기
        DrawPath();
    }

  

    private void DrawPath()
    {
        if(hasItem)
        {
            // Line Renderer 컴포넌트 가져오기
            LineRenderer lineRenderer = pathObject.GetComponent<LineRenderer>();

            //경로의 자표를 Line Renderer에 설정
            lineRenderer.positionCount = pathPoints.Count;
            lineRenderer.SetPositions(pathPoints.ToArray());
        }
    }

    //아이템을 흭득할 때 호출되는
    public void AcquireItem(string itemName)
    {
        if (!hasItem)
        {
            // 특정 아이템을 획득하면 경로를 표시하도록 설정
            if (itemName == "SpecialItem")
            {
                hasItem = true;
                acquiredItemName = itemName;
                TogglePathDisplay();
            }
        }
    }

    //경로 표시 활성화/비활성화
    private void TogglePathDisplay()
    {
        pathObject.SetActive(hasItem);
    }
}
