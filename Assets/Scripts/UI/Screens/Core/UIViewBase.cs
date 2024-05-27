using UnityEngine;

public abstract class UIViewBase : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup = null;

    protected UIPresenterBase Presenter { get; set; }


    public virtual void ShowScreen()
    {
        SetVisible(true);
        OnSubscribe();
        OnShowed(true);
    }

    public virtual void HideScreen()
    {
        SetVisible(false);
        OnUnsubscribe();
        OnShowed(false);
    }


    public virtual void OnInitialize()
    {
        //---
    }

    public virtual void OnDeinitialize()
    {
        //---
    }


    protected virtual void OnSubscribe()
    {
        Presenter.OnSubscribe();
    }

    protected virtual void OnUnsubscribe()
    {
        Presenter.OnUnsubscribe();
    }

    protected virtual void OnShowed(bool isVisible)
    {
        Presenter.OnShowed(isVisible);
    }

    protected virtual void CloseSelf()
    {
        Presenter.CloseSelf();
    }

    protected virtual void SetVisible(bool isVisible)
    {
        canvasGroup.alpha          = isVisible ? 1.0f : 0.0f;
        canvasGroup.interactable   = isVisible;
        canvasGroup.blocksRaycasts = isVisible;
    }
}