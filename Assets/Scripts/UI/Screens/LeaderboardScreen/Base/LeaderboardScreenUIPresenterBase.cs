public abstract class LeaderboardScreenUIPresenterBase : UIPresenterBase
{
    protected new LeaderboardScreenUIModelBase Model
    {
        get => base.Model as LeaderboardScreenUIModelBase;
        set => base.Model = value;
    }


    protected LeaderboardScreenUIPresenterBase(LeaderboardScreenUIModelBase model)
    {
        Model = model;
    }
}