using Zenject;

public abstract class GameOverScreenUIViewBase : UIViewBase
{
    protected new GameOverScreenUIPresenterBase Presenter
    {
        get => base.Presenter as GameOverScreenUIPresenterBase;
        set => base.Presenter = value;
    }


    [Inject]
    public void Construct(GameOverScreenUIPresenterBase presenter)
    {
        Presenter = presenter;
    }
}