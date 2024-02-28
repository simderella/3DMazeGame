using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour
{
    public Image titleImage; 

    private void Start()
    {
         titleImage.enabled = true;
    }

    public void OnGameStartButtonClicked()
    {
        titleImage.enabled = false;
    }
}
