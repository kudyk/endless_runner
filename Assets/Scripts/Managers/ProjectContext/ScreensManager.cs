using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreensManager
{
    private readonly Dictionary<Type, UIModelBase> availableScreens = new Dictionary<Type, UIModelBase>();
    private readonly Stack<UIModelBase>            openedScreens    = new Stack<UIModelBase>();


    public void Init(List<UIModelBase> screens)
    {
        if (screens == null)
            return;

        foreach (UIModelBase screen in screens)
        {
            screen.ScreenHide();
            availableScreens.Add(screen.GetType(), screen);
        }
    }

    public void Deinit()
    {
        availableScreens.Clear();
        openedScreens.Clear();
    }

    public void OpenScreen(Type screenType)
    {
        if (screenType == null)
            return;

        if (!availableScreens.ContainsKey(screenType))
        {
            Debug.LogError($"Incorrect or unregistered screen type {screenType}!");
            return;
        }

        if (TryToOpenFromStacked(screenType))
            return;

        TryToOpenNewScreen(screenType);
    }

    public void CloseLastScreen()
    {
        if (openedScreens.Count == 0)
        {
            Debug.LogError("All available screens are closed already!");
            return;
        }

        UIModelBase screenToClose = openedScreens.Pop();
        screenToClose.ScreenHide();

        if (openedScreens.TryPeek(out UIModelBase screenToOpen))
            screenToOpen.ScreenShow();
    }


    private bool TryToOpenFromStacked(Type screenType)
    {
        if (openedScreens.All(x => x.GetType() != screenType))
            return false;

        while (openedScreens.Count > 0)
        {
            UIModelBase lastScreen = openedScreens.Peek();
            if (lastScreen.GetType() == screenType)
            {
                lastScreen.ScreenShow();
                return true;
            }

            UIModelBase screenToClose = openedScreens.Pop();
            screenToClose.ScreenHide();
        }

        return false;
    }

    private void TryToOpenNewScreen(Type screenType)
    {
        if (openedScreens.TryPeek(out UIModelBase screenToClose))
            screenToClose.ScreenHide();

        UIModelBase screenToOpen = availableScreens[screenType];
        openedScreens.Push(screenToOpen);
        screenToOpen.ScreenShow();
    }
}