using UnityEngine;

public abstract class CharacterViewBase : MonoBehaviour
{
    public abstract void SetIdle();
    public abstract void UpdateForwardMovementState(float movementParam);
    public abstract void ShowTurningState(TurningState turningState);
    public abstract void SetDead();
}

public enum TurningState
{
    NONE  = 0,
    LEFT  = 1,
    RIGHT = 2,
}