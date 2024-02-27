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

        // GameObject.Find���� Portal red�� ã���� ����
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
