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
        SceneManager.LoadScene("02.LoadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        // �񵿱������� ���� �ε��ϰ� �ش� �۾��� AsyncOperation�� ����
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneNum);

        // �� Ȱ��ȭ�� �����ϴ� �÷��� ����
        sceneLoad.allowSceneActivation = false;

        float timer = 0.0f;

        // �� �ε尡 �Ϸ�� ������ �ݺ�
        while (!sceneLoad.isDone)
        {
            yield return null;
            timer += Time.deltaTime * 0.2f;

            // �� �ε� ���൵�� 0.9���� ���� ��
            if (sceneLoad.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, sceneLoad.progress, timer);
                if (progressBar.fillAmount >= sceneLoad.progress)
                {
                    timer = 0.0f;
                }
            }
            // �� �ε� ���൵�� 0.9 �̻��� ��
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    sceneLoad.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
