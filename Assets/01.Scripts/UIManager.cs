using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text textinstage5;
    private static UIManager _instance;
    public string goodjob ;
    public bool intutorial;
    public TMP_Text description;
    //public Image healthbar;
    //private CharacterHealth characterhealth;
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

    }
    private void Start()
    {
        goodjob = "��Ż�� Ȱ��ȭ�Ǿ����ϴ�.";
        intutorial = true;
        //characterhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
    }

    private void Update()
    {
        if(textinstage5 != null)
        {
            if (gameManager.remainswitchintutorial == 1)
            {
                textinstage5.text = "������ ������ ���� ��������";
            }
            else
            {
                if (intutorial == true)
                {
                    textinstage5.text = "��Ż�� �����ϼ���";
                }
                else
                {
                    if (gameManager.remainswitch != 0)
                    {
                        RemainSwitch(gameManager.remainswitch);
                    }
                    else
                    {
                        textinstage5.text = goodjob;
                    }
                }
            }
        }
        //healthbar.fillAmount = characterhealth.GetPercentage();
    }



    public void RemainSwitch(int remainswitch)
    {
        textinstage5.text = "��Ż�� Ȱ��ȭ��Ű�� ���� ���� ���������� ���� :" + remainswitch.ToString();
    }


}
