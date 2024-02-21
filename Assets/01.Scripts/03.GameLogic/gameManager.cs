using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    [HideInInspector] public static int remainswitch;
    [HideInInspector] public static int remainswitchintutorial;
    public GameObject portal;
    public GameObject portaltutorial;
    public bool goToStartScene;

    [SerializeField] private TextMeshProUGUI _timerText;
    private float _timer;
    private bool isPlaying = false;

    private static gameManager _instance;

    public static gameManager Instance
    {
        get
        {

            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(gameManager)) as gameManager;
            }
            return _instance;
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 30;
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        portaltutorial.SetActive(false);
        portal.SetActive(false);
        remainswitchintutorial = 1;
        remainswitch = 3;
    }

    private void Update()
    {
        if (remainswitchintutorial == 0)
        {
            portaltutorial.SetActive(true);
        }
        
        if (remainswitch == 0)
        {
            portal.SetActive(true);
        }

        if(goToStartScene)
        {
            StartCoroutine("GoToStartScene");
        }

        Application.targetFrameRate = 60;
    }
    
    IEnumerator GoToStartScene()
    {
        yield return new WaitForSeconds(5.0f);
        SaveAndLoadTime();
        LoadSceneManager.LoadScene(0);
    }

    public void GameStart()
    {
        StartCoroutine(TimerStart());
    }

    IEnumerator TimerStart()
    {
        _timer = 0f;
        isPlaying = true;
        while (isPlaying)
        {
            _timer += Time.deltaTime;
            SetTimerText(_timer);
            yield return null;
        }

        isPlaying = false;
    }

    void SaveAndLoadTime()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetFloat($"Maze{sceneIndex}TimeAttack", _timer);
        PlayerPrefs.Save();
    }

    void gameOver()
    {
        //플레이어 health == 0 일때
    }

    void SetTimerText(float time)
    {
        string min = Mathf.Floor(time / 60).ToString("00");
        string sec = (time % 60).ToString("00");
        _timerText.text = string.Format("{0}:{1}", min, sec);
    }
}
