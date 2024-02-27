using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform playerTransform;
    private Transform exitTransform;
    public GameObject compassArrowPrefab;
    public LineRenderer lineRenderer;
    public bool useCompass;
    public float activeTime;

    private float timer;

    private void Start()
    {
        playerTransform = GameObject.Find("ItemHolder")?.transform;

        // GameObject.Find에서 Portal red를 찾도록 수정
        GameObject portalRed = GameObject.Find("Portal red");
        if (portalRed != null)
        {
            exitTransform = portalRed.transform;
        }

        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (playerTransform != null && exitTransform != null)
        {
            if (useCompass)
            {
                timer += Time.deltaTime;

                if (timer < activeTime)
                {
                    UpdateLineRenderer();
                }
                else
                {
                    DestroyCompass();
                }
            }
            else
            {
                lineRenderer.enabled = false;

            }
        }
    }

    private void UpdateLineRenderer()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, playerTransform.position);
        lineRenderer.SetPosition(1, exitTransform.position);
    }

    private void DestroyCompass()
    {
        lineRenderer.enabled = false;
        Destroy(gameObject);
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
