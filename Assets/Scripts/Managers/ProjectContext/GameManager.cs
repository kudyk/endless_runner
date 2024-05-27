using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene(SceneType sceneType)
    {
        int sceneID = GetSceneName();

        if (sceneID == -1)
            return;

        SceneManager.LoadScene(sceneID);

        int GetSceneName()
        {
            switch (sceneType)
            {
                case SceneType.LOADING:
                    return 0;
                case SceneType.MAIN_MENU:
                    return 1;
                case SceneType.GAMEPLAY:
                    return 2;
                default: return -1;
            }
        }
    }
}

public enum SceneType
{
    NONE      = 0,
    LOADING   = 1,
    MAIN_MENU = 2,
    GAMEPLAY  = 3,
}