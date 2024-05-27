using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class CharacterModelBase : MonoBehaviour
{
    protected CharacterViewBase view         = null;
    protected CharacterState    currentState = null;

    protected abstract Dictionary<CharacterAvailableStates, CharacterState> AvailableStates { get; }


    [Inject]
    private void Construct(CharacterViewBase view)
    {
        this.view = view;
    }

    public virtual void InitState(CharacterAvailableStates state)
    {
        currentState?.ExitState();
        currentState = AvailableStates[state];
        currentState?.InitState();
    }

    public virtual void UpdateMovementSpeedState(float movementParam)
    {
        currentState?.UpdateMovementSpeedState(movementParam);
    }

    public virtual void MoveLeft()
    {
        currentState?.MoveLeft();
    }

    public virtual void MoveRight()
    {
        currentState?.MoveRight();
    }
}

public enum CharacterAvailableStates
{
    NONE    = 0,
    IDLE    = 1,
    RUNNING = 2,
    DEAD    = 3,
}