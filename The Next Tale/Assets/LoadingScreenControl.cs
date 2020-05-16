using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour
{
    public GameObject loadingScreenObj;
    public Slider slider;
    public Text progresstext;
    AsyncOperation async;
    public void LoadScreenExample(int index)
    {
        StartCoroutine(LoadingScreen(index));
    }

    IEnumerator LoadingScreen(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreenObj.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progresstext.text = progress * 100f + "%";
            yield return null;
        }
    }
}
