using UnityEngine;
using UnityEngine.UI;

public class MainScreenUIView : MainScreenUIViewBase
{
    [SerializeField] private Button uiButtonPlay        = null;
    [SerializeField] private Button uiButtonLeaderboard = null;
    [SerializeField] private Button uiButtonExit        = null;


    protected override void OnSubscribe()
    {
        base.OnSubscribe();

        uiButtonPlay.onClick.AddListener(OnPlayButtonClick);
        uiButtonLeaderboard.onClick.AddListener(OnLeaderboardButtonClick);
        uiButtonExit.onClick.AddListener(OnExitButtonClick);
    }

    protected override void OnUnsubscribe()
    {
        base.OnUnsubscribe();

        uiButtonPlay.onClick.RemoveListener(OnPlayButtonClick);
        uiButtonLeaderboard.onClick.RemoveListener(OnLeaderboardButtonClick);
        uiButtonExit.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick()
    {
        Presenter.HandlePlayGameInput();
    }

    private void OnLeaderboardButtonClick()
    {
        Presenter.HandleOpenLeaderboardInput();
    }

    private void OnExitButtonClick()
    {
        Presenter.HandleExitGameInput();
    }
}