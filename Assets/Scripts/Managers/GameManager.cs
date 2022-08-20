using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;

    private float totalSceneProgress;

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
    }

    public void LoadMainMenu(string location)
    {
        loadingScreen.gameObject.SetActive(true);

        if (location == "game")
        {
            scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.GAME));
        }
        else if (location == "bestScore")
        {
            scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.BEST_SCORE));
        }
        else if (location == "options")
        {
            scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.OPTIONS));
        }
        
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadingProgress((int)SceneIndexes.MAIN_MENU));
    }

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.GAME, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadingProgress((int)SceneIndexes.GAME));
    }

    public void ReloadGame()
    {
        loadingScreen.gameObject.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.GAME));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.GAME, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadingProgress((int)SceneIndexes.GAME));
    }

    public void LoadBestScores()
    {
        loadingScreen.gameObject.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.BEST_SCORE, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadingProgress((int)SceneIndexes.BEST_SCORE));
    }

    public void LoadOptions()
    {
        loadingScreen.gameObject.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.OPTIONS, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadingProgress((int)SceneIndexes.OPTIONS));
    }

    public void Exit()
    {
        Application.Quit();
    }

    public IEnumerator GetSceneLoadingProgress(int sceneIndex)
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0f;
                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;
                LoadingBar.current = Mathf.RoundToInt(totalSceneProgress);

                yield return null;
            }
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
        loadingScreen.gameObject.SetActive(false);
    }
}
