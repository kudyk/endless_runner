using Zenject;

public abstract class MainScreenUIModelBase : UIModelBase
{
    protected GameManager gameManager;

    protected new MainScreenUIViewBase View
    {
        get => base.View as MainScreenUIViewBase;
        set => base.View = value;
    }


    [Inject]
    protected void Construct(MainScreenUIViewBase view, GameManager gameManager)
    {
        View             = view;
        this.gameManager = gameManager;
    }


    public abstract void PlayGame();
    public abstract void ShowLeaderboardScreen();
    public abstract void ExitGame();
}