using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public void MainScene()
    {
        LoadSceneManager.LoadScene(0);
    }
    public void Stage1Change()
    {
        LoadSceneManager.LoadScene(1); 
    }

    public void Stage2Change()
    {
        LoadSceneManager.LoadScene(2);
    }

    public void Stage3Change()
    {
        LoadSceneManager.LoadScene(3);
    }
    public void Stage4Change()
    {
        LoadSceneManager.LoadScene(4);
    }
    public void Stage5Change()
    {
        LoadSceneManager.LoadScene(6);
    }


    public void UIPopupClose()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
