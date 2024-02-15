using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
{
    public Image titleImage; 

    private void Start()
    {
        // �ʱ⿡ Ÿ��Ʋ �̹����� ǥ���ϰ� �ʹٸ� �ּ� ó���ϼ���.
         titleImage.enabled = true;
    }

    public void OnGameStartButtonClicked()
    {
        // ���� ���� ��ư�� Ŭ���Ǹ� Ÿ��Ʋ �̹����� ����ϴ�.
        titleImage.enabled = false;
    }
}
