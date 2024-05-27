using Zenject;

public abstract class GameOverScreenUIModelBase : UIModelBase
{
    protected GameManager           gameManager     = null;
    protected RunnerGameplayManager gameplayManager = null;

    protected new GameOverScreenUIViewBase View
    {
        get => base.View as GameOverScreenUIViewBase;
        set => base.View = value;
    }

    
    [Inject]
    protected void Construct(GameOverScreenUIViewBase view, GameManager gameManager, RunnerGameplayManager gameplayManager)
    {
        View                 = view;
        this.gameManager     = gameManager;
        this.gameplayManager = gameplayManager;
    }

    public abstract void ReturnToMainMenu();
}