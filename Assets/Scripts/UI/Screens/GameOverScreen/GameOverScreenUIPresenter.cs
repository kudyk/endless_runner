public class GameOverScreenUIPresenter : GameOverScreenUIPresenterBase
{
    public GameOverScreenUIPresenter(GameOverScreenUIModelBase model) : base(model) { }

    public override void HandleReturnToMainMenuInput()
    {
        Model.ReturnToMainMenu();
    }
}