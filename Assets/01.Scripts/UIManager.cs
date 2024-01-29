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
        goodjob = "포탈이 활성화되었습니다.";
        intutorial = true;
        //characterhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
    }

    private void Update()
    {
        if(textinstage5 != null)
        {
            if (gameManager.remainswitchintutorial == 1)
            {
                textinstage5.text = "눈앞의 에너지 볼을 모으세요";
            }
            else
            {
                if (intutorial == true)
                {
                    textinstage5.text = "포탈로 입장하세요";
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
        textinstage5.text = "포탈을 활성화시키기 위한 남은 에너지볼의 개수 :" + remainswitch.ToString();
    }


}
