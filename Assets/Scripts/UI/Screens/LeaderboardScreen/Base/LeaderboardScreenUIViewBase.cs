using Zenject;

public abstract class LeaderboardScreenUIViewBase : UIViewBase
{
    protected new LeaderboardScreenUIPresenterBase Presenter
    {
        get => base.Presenter as LeaderboardScreenUIPresenterBase;
        set => base.Presenter = value;
    }


    [Inject]
    public void Construct(LeaderboardScreenUIPresenterBase presenter)
    {
        Presenter = presenter;
    }

    public abstract void ShowBestScores(AttemptsSaveData[] scores);
}