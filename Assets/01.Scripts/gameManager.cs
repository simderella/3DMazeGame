using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    [HideInInspector] public static int remainswitch = 3;
    [HideInInspector] public static int previousswitch = remainswitch;
    public GameObject portal;


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

        DontDestroyOnLoad(gameObject);
        portal.SetActive(false);
        remainswitch = 3;
    }

    private void Update()
    {
        
        if (remainswitch == 0)
        {
            portal.SetActive(true);
        }
    }


    
}
