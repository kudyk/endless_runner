public abstract class CharacterState
{
    protected CharacterModelBase model;
    protected CharacterViewBase  view;


    public CharacterState(CharacterModelBase model, CharacterViewBase view)
    {
        this.model = model;
        this.view  = view;
    }

    public virtual void InitState()
    {
        //---
    }

    public virtual void ExitState()
    {
        //---
    }

    public virtual void UpdateMovementSpeedState(float movementParam)
    {
        //---
    }

    public virtual void MoveLeft()
    {
        //---
    }

    public virtual void MoveRight()
    {
        //---
    }
}