using UnityEngine;
using Zenject;

public abstract class UIModelBase : MonoBehaviour
{
    [Inject]
    protected ScreensManager screensManager;

    protected UIViewBase View { get; set; }


    private void Start()
    {
        OnInitialize();
    }

    private void OnDestroy()
    {
        OnDeinitialize();
    }


    public virtual void ScreenShow()
    {
        View.ShowScreen();
    }

    public virtual void ScreenHide()
    {
        View.HideScreen();
    }

    public virtual void CloseSelf()
    {
        screensManager.CloseLastScreen();
    }


    protected virtual void OnInitialize()
    {
        View.OnInitialize();
    }

    protected virtual void OnDeinitialize()
    {
        View.OnDeinitialize();
    }

    public virtual void OnSubscribe()
    {
        //---
    }

    public virtual void OnUnsubscribe()
    {
        //---
    }

    public virtual void OnShoved(bool isVisible)
    {
        //---
    }
}