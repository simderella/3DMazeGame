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
        Time.timeScale = 1.0f;
    }
    public void Stage1Change()
    {
        LoadSceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void Stage2Change()
    {
        LoadSceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }

    public void Stage3Change()
    {
        LoadSceneManager.LoadScene(3);
        Time.timeScale = 1.0f;
    }
    public void Stage4Change()
    {
        LoadSceneManager.LoadScene(4);
        Time.timeScale = 1.0f;
    }
    public void Stage5Change()
    {
        LoadSceneManager.LoadScene(5);
        Time.timeScale = 1.0f;
    }

    public void ReSetScene()
    {
        LoadSceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }


    public void UIPopupClose()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
