using Zenject;

public abstract class HUDScreenUIViewBase : UIViewBase
{
    protected new HUDScreenUIPresenterBase Presenter
    {
        get => base.Presenter as HUDScreenUIPresenterBase;
        set => base.Presenter = value;
    }


    [Inject]
    public void Construct(HUDScreenUIPresenterBase presenter)
    {
        Presenter = presenter;
    }

    public abstract void UpdateScores(int lowValue, int mediumValue, int highValue, int totalValue);
}