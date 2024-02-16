using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeAttackText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _maze1Time;
    [SerializeField] private TextMeshProUGUI _maze2Time;
    [SerializeField] private TextMeshProUGUI _maze3Time;
    [SerializeField] private TextMeshProUGUI _maze4Time;
    [SerializeField] private TextMeshProUGUI _maze5Time;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs에서 저장된 기록을 불러옴
        float Maze1TimeAttack = PlayerPrefs.GetFloat("Maze1TimeAttack", 0f);
        float Maze2TimeAttack = PlayerPrefs.GetFloat("Maze2TimeAttack", 0f);
        float Maze3TimeAttack = PlayerPrefs.GetFloat("Maze3TimeAttack", 0f);
        float Maze4TimeAttack = PlayerPrefs.GetFloat("Maze4TimeAttack", 0f);
        float Maze5TimeAttack = PlayerPrefs.GetFloat("Maze5TimeAttack", 0f);
        // 이전 씬에서의 기록을 텍스트로 표시
        if (Maze1TimeAttack != null)
        {
            Maze1TimeText(Maze1TimeAttack);
        }
        if (Maze2TimeAttack != null)
        {
            Maze2TimeText(Maze2TimeAttack);
        }
        if (Maze3TimeAttack != null)
        {
            Maze3TimeText(Maze3TimeAttack);
        }
        if (Maze4TimeAttack != null)
        {
            Maze4TimeText(Maze4TimeAttack);
        }
        if (Maze5TimeAttack != null)
        {
            Maze5TimeText(Maze5TimeAttack);
        }

    }

    void Maze1TimeText(float time)
    {
        string min = Mathf.Floor(time / 60).ToString("00");
        string sec = (time % 60).ToString("00");
        if (_maze1Time != null)
            _maze1Time.text = string.Format("LastTime {0}:{1}", min, sec);
    }
    void Maze2TimeText(float time)
    {
        string min = Mathf.Floor(time / 60).ToString("00");
        string sec = (time % 60).ToString("00");
        if (_maze2Time != null)
            _maze2Time.text = string.Format("LastTime {0}:{1}", min, sec);
    }
    void Maze3TimeText(float time)
    {
        string min = Mathf.Floor(time / 60).ToString("00");
        string sec = (time % 60).ToString("00");
        if (_maze3Time != null)
            _maze3Time.text = string.Format("LastTime {0}:{1}", min, sec);
    }
    void Maze4TimeText(float time)
    {
        string min = Mathf.Floor(time / 60).ToString("00");
        string sec = (time % 60).ToString("00");
        if (_maze4Time != null)
            _maze4Time.text = string.Format("LastTime {0}:{1}", min, sec);
    }
    void Maze5TimeText(float time)
    {
        string min = Mathf.Floor(time / 60).ToString("00");
        string sec = (time % 60).ToString("00");
        if (_maze5Time != null)
            _maze5Time.text = string.Format("LastTime {0}:{1}", min, sec);
    }

    public void ResetTimeAttack()
    {
        PlayerPrefs.DeleteKey("Maze1TimeAttack");
        PlayerPrefs.DeleteKey("Maze2TimeAttack");
        PlayerPrefs.DeleteKey("Maze3TimeAttack");
        PlayerPrefs.DeleteKey("Maze4TimeAttack");
        PlayerPrefs.DeleteKey("Maze5TimeAttack");
        PlayerPrefs.Save();
        LoadSceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        //다음에 불러올 때 키에 대한 값이 없으므로 기본값을 0f로 반환
    }
}
