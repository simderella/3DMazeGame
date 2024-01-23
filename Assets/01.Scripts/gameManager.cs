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
    [HideInInspector] public static int remainswitch = 3;
    [HideInInspector] public static int remainswitchintutorial = 1;
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

        portal.SetActive(false);
        remainswitch = 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameStart();
        }
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
    }
    
    IEnumerator GoToStartScene()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("StartScene");
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
            string min = Mathf.Floor(_timer / 60).ToString("00");
            string sec = (_timer % 60).ToString("00");
            _timerText.text = string.Format("{0}:{1}", min, sec);
            yield return null;

            //if (GameOver)
            //{

            //}
        }
    }
}
