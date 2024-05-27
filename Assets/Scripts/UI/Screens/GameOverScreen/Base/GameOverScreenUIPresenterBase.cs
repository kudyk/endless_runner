public abstract class GameOverScreenUIPresenterBase : UIPresenterBase
{
    protected new GameOverScreenUIModelBase Model
    {
        get => base.Model as GameOverScreenUIModelBase;
        set => base.Model = value;
    }


    protected GameOverScreenUIPresenterBase(GameOverScreenUIModelBase model)
    {
        Model = model;
    }

    public abstract void HandleReturnToMainMenuInput();
}