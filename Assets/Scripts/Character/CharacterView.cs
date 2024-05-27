using UnityEngine;

public class CharacterView : CharacterViewBase
{
    [SerializeField] private Animator animator         = null;
    [SerializeField] private string   movementStateKey = string.Empty;
    [SerializeField] private string   idleStateKey     = string.Empty;
    [SerializeField] private string   deadStateKey     = string.Empty;


    public override void SetIdle()
    {
        animator.SetFloat(movementStateKey, 0.0f);
        animator.Play(idleStateKey);
    }

    public override void UpdateForwardMovementState(float movementParam)
    {
        animator.SetFloat(movementStateKey, Mathf.Abs(movementParam));
    }

    public override void ShowTurningState(TurningState turningState)
    {
        //for future advanced inheritors like with rotating views or additional animation states
    }

    public override void SetDead()
    {
        animator.SetFloat(movementStateKey, 0.0f);
        animator.Play(deadStateKey);
    }
}