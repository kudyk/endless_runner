using Zenject;

public abstract class HUDScreenUIModelBase : UIModelBase
{
    protected RunnerProgressManager progressManager;

    protected new HUDScreenUIViewBase View
    {
        get => base.View as HUDScreenUIViewBase;
        set => base.View = value;
    }


    [Inject]
    protected void Construct(HUDScreenUIViewBase view, RunnerProgressManager progressManager)
    {
        View                 = view;
        this.progressManager = progressManager;
    }
}