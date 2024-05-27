using UnityEngine;
using Zenject;

public class MainMenuManager : MonoBehaviour
{
    private ScreensManager screensManager = null;


    [Inject]
    private void Construct(ScreensManager screensManager)
    {
        this.screensManager = screensManager;
    }

    private void Start()
    {
        screensManager.OpenScreen(typeof(MainScreenUIModel));
    }
}