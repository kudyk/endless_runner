using System.Collections.Generic;
using UnityEngine;
using Zenject;

// Some temporary solution to avoid Zenject looped dependencies binding error.
public class DeferredScreensDependenciesInstaller : MonoBehaviour
{
    private ScreensManager screensManager = null;


    [Inject]
    private void Construct(List<UIModelBase> screens, ScreensManager screensManager)
    {
        this.screensManager = screensManager;

        screensManager.Init(screens);
    }

    private void OnDestroy()
    {
        screensManager.Deinit();
    }
}