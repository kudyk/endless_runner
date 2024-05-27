using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private UIProgressBar progressBar     = null;
    [SerializeField] private float         minLoadingTime  = 3.0f;
    [SerializeField] private string        nextSceneToLoad = string.Empty;

    private const float SCENE_LOADED_STATE = 0.9f;


    private IEnumerator Start()
    {
        float loadingFinishTime = Time.unscaledTime + minLoadingTime;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(nextSceneToLoad, LoadSceneMode.Single);
        if (asyncOperation == null)
            throw new InvalidOperationException($"Can't load {nextSceneToLoad} scene, {nameof(asyncOperation)} == null!");

        asyncOperation.allowSceneActivation = false;
        while (asyncOperation.progress < SCENE_LOADED_STATE)
        {
            progressBar.UpdateProgressClamped(asyncOperation.progress);
            yield return null;
            progressBar.UpdateProgressClamped(asyncOperation.progress);
        }

        if (loadingFinishTime < Time.unscaledTime)
        {
            asyncOperation.allowSceneActivation = true;
            yield break;
        }

        yield return new WaitUntil(() => loadingFinishTime < Time.unscaledTime);
        asyncOperation.allowSceneActivation = true;
    }
}