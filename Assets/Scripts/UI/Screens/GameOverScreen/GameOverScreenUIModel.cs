public class GameOverScreenUIModel : GameOverScreenUIModelBase
{
    public override void ReturnToMainMenu()
    {
        gameplayManager.SaveCurrentAttemptProgress();
        gameManager.LoadScene(SceneType.MAIN_MENU);
    }
}