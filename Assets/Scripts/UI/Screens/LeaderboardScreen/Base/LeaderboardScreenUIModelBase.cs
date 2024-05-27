using Zenject;

public abstract class LeaderboardScreenUIModelBase : UIModelBase
{
    protected GameSavesManager savesManager = null;

    protected new LeaderboardScreenUIViewBase View
    {
        get => base.View as LeaderboardScreenUIViewBase;
        set => base.View = value;
    }


    [Inject]
    protected void Construct(LeaderboardScreenUIViewBase view, GameSavesManager savesManager)
    {
        View              = view;
        this.savesManager = savesManager;
    }
}