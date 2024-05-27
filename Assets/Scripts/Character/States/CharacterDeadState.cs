public class CharacterDeadState : CharacterState
{
    public CharacterDeadState(CharacterModelBase model, CharacterViewBase view) : base(model, view) { }

    public override void InitState()
    {
        view.SetDead();
    }
}