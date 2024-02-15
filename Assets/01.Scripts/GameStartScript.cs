using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
{
    public Image titleImage; 

    private void Start()
    {
        // 초기에 타이틀 이미지를 표시하고 싶다면 주석 처리하세요.
         titleImage.enabled = true;
    }

    public void OnGameStartButtonClicked()
    {
        // 게임 시작 버튼이 클릭되면 타이틀 이미지를 숨깁니다.
        titleImage.enabled = false;
    }
}
