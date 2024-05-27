public abstract class UIPresenterBase
{
    protected UIModelBase Model { get; set; }


    public void CloseSelf()
    {
        Model.CloseSelf();
    }

    public void OnSubscribe()
    {
        Model.OnSubscribe();
    }

    public void OnUnsubscribe()
    {
        Model.OnUnsubscribe();
    }

    public void OnShowed(bool isVisible)
    {
        Model.OnShoved(isVisible);
    }
}