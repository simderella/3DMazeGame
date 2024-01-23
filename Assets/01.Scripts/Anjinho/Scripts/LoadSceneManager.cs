using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
    public static int sceneNum;

    [SerializeField] Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(int index)
    {
        sceneNum = index;
        //SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        // 비동기적으로 씬을 로드하고 해당 작업을 AsyncOperation에 저장
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneNum);

        // 씬 활성화를 제어하는 플래그 설정
        sceneLoad.allowSceneActivation = false;

        float timer = 0.0f;

        // 씬 로드가 완료될 때까지 반복
        while (!sceneLoad.isDone)
        {
            yield return null;
            timer += 0.0005f;

            // 씬 로드 진행도가 0.9보다 작을 때
            if (sceneLoad.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, sceneLoad.progress, timer);
                if (progressBar.fillAmount >= sceneLoad.progress)
                {
                    timer = 0.0f;
                }
            }
            // 씬 로드 진행도가 0.9 이상일 때
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    sceneLoad.allowSceneActivation = true;
                    Time.timeScale = 1.0f;
                    yield break;
                }
            }
        }
    }
}
