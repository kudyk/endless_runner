public abstract class HUDScreenUIPresenterBase : UIPresenterBase
{
    protected new HUDScreenUIModelBase Model
    {
        get => base.Model as HUDScreenUIModelBase;
        set => base.Model = value;
    }


    protected HUDScreenUIPresenterBase(HUDScreenUIModelBase model)
    {
        Model = model;
    }
}