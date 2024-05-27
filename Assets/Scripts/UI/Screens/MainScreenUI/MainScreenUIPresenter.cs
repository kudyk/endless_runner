public class MainScreenUIPresenter : MainScreenUIPresenterBase
{
    public MainScreenUIPresenter(MainScreenUIModelBase model) : base(model) { }

    public override void HandlePlayGameInput()
    {
        Model.PlayGame();
    }

    public override void HandleOpenLeaderboardInput()
    {
        Model.ShowLeaderboardScreen();
    }

    public override void HandleExitGameInput()
    {
        Model.ExitGame();
    }
}