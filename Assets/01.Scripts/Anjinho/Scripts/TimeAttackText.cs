using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAttackText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _previousTimeText;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs���� ����� ����� �ҷ���
        float Maze4TimeAttack = PlayerPrefs.GetFloat("Maze4TimeAttack", 0f);

        // ���� �������� ����� �ؽ�Ʈ�� ǥ��
        SetPreviousTimeText(Maze4TimeAttack);
    }

    void SetPreviousTimeText(float time)
    {
        string min = Mathf.Floor(time / 60).ToString("00");
        string sec = (time % 60).ToString("00");
        _previousTimeText.text = string.Format("LastTime {0}:{1}", min, sec);
    }
}
