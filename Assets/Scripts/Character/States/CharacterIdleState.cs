public class CharacterIdleState : CharacterState
{
    public CharacterIdleState(CharacterModelBase model, CharacterViewBase view) : base(model, view) { }

    public override void InitState()
    {
        view.SetIdle();
    }
}