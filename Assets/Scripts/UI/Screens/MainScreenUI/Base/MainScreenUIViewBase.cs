using Zenject;

public abstract class MainScreenUIViewBase : UIViewBase
{
    protected new MainScreenUIPresenterBase Presenter
    {
        get => base.Presenter as MainScreenUIPresenterBase;
        set => base.Presenter = value;
    }


    [Inject]
    public void Construct(MainScreenUIPresenterBase presenter)
    {
        Presenter = presenter;
    }
}