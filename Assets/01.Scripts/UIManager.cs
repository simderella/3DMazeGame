using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public TMP_Text text;
    private static UIManager _instance;
    


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
        
    }

    private void Update()
    {
        if (gameManager.remainswitch != 0)
        {
            RemainSwitch(gameManager.remainswitch);
        }
        else
        {
            UIManager.Instance.text.text = "��Ż�� Ȱ��ȭ�Ǿ����ϴ�.";
        }
    }



    void RemainSwitch(int remainswitch)
    {
        UIManager.Instance.text.text = "��Ż�� Ȱ��ȭ��Ű�� ���� ���� ���������� ���� :" + remainswitch.ToString();
    }

}
