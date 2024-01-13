using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public TMP_Text text;
    private static UIManager _instance;
    public string goodjob ;



    public static UIManager Instance
    {
        get
        {

            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(UIManager)) as UIManager;
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

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        goodjob = "포탈이 활성화되었습니다.";
    }

    private void Update()
    {
        if (gameManager.remainswitch != 0)
        {
            RemainSwitch(gameManager.remainswitch);
        }
        else
        {
            Debug.Log(goodjob);
            text.text = goodjob;
        }
    }



    void RemainSwitch(int remainswitch)
    {
        text.text = "포탈을 활성화시키기 위한 남은 에너지볼의 개수 :" + remainswitch.ToString();
    }


}
