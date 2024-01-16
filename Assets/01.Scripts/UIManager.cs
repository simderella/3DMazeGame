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
    public bool intutorial;



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
        goodjob = "��Ż�� Ȱ��ȭ�Ǿ����ϴ�.";
        intutorial = true;
    }

    private void Update()
    {
        if(gameManager.remainswitchintutorial == 1)
        {
            text.text = "������ ������ ���� ��������";
        }
        else
        {
            if (intutorial == true)
            {
                text.text = "��Ż�� �����ϼ���";
            }
            else 
            {
                if (gameManager.remainswitch != 0)
                {
                    RemainSwitch(gameManager.remainswitch);
                }
                else
                {
                    text.text = goodjob;
                }
            }
        }
    }



    public void RemainSwitch(int remainswitch)
    {
        text.text = "��Ż�� Ȱ��ȭ��Ű�� ���� ���� ���������� ���� :" + remainswitch.ToString();
    }


}
