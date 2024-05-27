public abstract class MainScreenUIPresenterBase : UIPresenterBase
{
    protected new MainScreenUIModelBase Model
    {
        get => base.Model as MainScreenUIModelBase;
        set => base.Model = value;
    }


    protected MainScreenUIPresenterBase(MainScreenUIModelBase model)
    {
        Model = model;
    }

    public abstract void HandlePlayGameInput();

    public abstract void HandleOpenLeaderboardInput();

    public abstract void HandleExitGameInput();
}