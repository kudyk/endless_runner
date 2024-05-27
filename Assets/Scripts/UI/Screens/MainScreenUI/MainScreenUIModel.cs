public class MainScreenUIModel : MainScreenUIModelBase
{
    public override void PlayGame()
    {
        gameManager.LoadScene(SceneType.GAMEPLAY);
    }

    public override void ShowLeaderboardScreen()
    {
        screensManager.OpenScreen(typeof(LeaderboardScreenUIModel));
    }

    public override void ExitGame()
    {
        gameManager.ExitGame();
    }
}