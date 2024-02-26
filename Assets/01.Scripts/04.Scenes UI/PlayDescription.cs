using UnityEngine;

public class PlayDescription : MonoBehaviour
{
    public GameObject keyDescriptionPanel;  // �Է� Ű ������ ��� �ִ� �г�
    public float displayTime = 10f;  // â�� ǥ�õǴ� �ð� (��)

    private void Start()
    {
        // ������ ���۵� �� â�� ǥ���ϰ� ���� �ð� �Ŀ� ����
        ShowKeyDescription();
        Invoke("HideKeyDescription", displayTime);
    }

    private void ShowKeyDescription()
    {
        // �Է� Ű ���� â�� Ȱ��ȭ
        keyDescriptionPanel.SetActive(true);
    }

    private void HideKeyDescription()
    {
        // �Է� Ű ���� â�� ��Ȱ��ȭ
        keyDescriptionPanel.SetActive(false);
    }
}
