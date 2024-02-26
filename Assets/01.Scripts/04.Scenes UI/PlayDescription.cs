using UnityEngine;

public class PlayDescription : MonoBehaviour
{
    public GameObject keyDescriptionPanel;  // 입력 키 설명을 담고 있는 패널
    public float displayTime = 10f;  // 창이 표시되는 시간 (초)

    private void Start()
    {
        // 게임이 시작될 때 창을 표시하고 일정 시간 후에 숨김
        ShowKeyDescription();
        Invoke("HideKeyDescription", displayTime);
    }

    private void ShowKeyDescription()
    {
        // 입력 키 설명 창을 활성화
        keyDescriptionPanel.SetActive(true);
    }

    private void HideKeyDescription()
    {
        // 입력 키 설명 창을 비활성화
        keyDescriptionPanel.SetActive(false);
    }
}
