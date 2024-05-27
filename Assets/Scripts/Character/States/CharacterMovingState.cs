using System;
using System.Collections;
using UnityEngine;

public class CharacterMovingState : CharacterState
{
    private bool isChangingPosition   = false;
    private int  currentPositionIndex = 0;

    private IEnumerator           positionChangeCoroutine;
    private RunnerCharacterConfig characterConfig;


    public CharacterMovingState(RunnerCharacterConfig characterConfig, CharacterModelBase model, CharacterViewBase view) : base(model, view)
    {
        this.characterConfig = characterConfig;
    }

    public override void InitState()
    {
        TryToStopCoroutine(positionChangeCoroutine);

        currentPositionIndex     = characterConfig.defaultPositionIndex;
        model.transform.position = characterConfig.positionStates[currentPositionIndex];
    }

    public override void UpdateMovementSpeedState(float movementParam)
    {
        view.UpdateForwardMovementState(movementParam);
    }

    public override void MoveLeft()
    {
        TryToMoveCharacter(false);
    }

    public override void MoveRight()
    {
        TryToMoveCharacter(true);
    }

    public override void ExitState()
    {
        TryToStopCoroutine(positionChangeCoroutine);

        base.ExitState();
    }


    private void TryToMoveCharacter(bool isMoveRight)
    {
        if (isChangingPosition)
            return;

        if (!CanChangePosition(isMoveRight))
            return;

        int targetPositionIndex = isMoveRight ? currentPositionIndex + 1 : currentPositionIndex - 1;

        positionChangeCoroutine = CharacterPositionChangeCoroutine(model.transform.position, characterConfig.positionStates[targetPositionIndex], () => currentPositionIndex = targetPositionIndex);
        model.StartCoroutine(positionChangeCoroutine);
    }

    private IEnumerator CharacterPositionChangeCoroutine(Vector3 startPosition, Vector3 targetPosition, Action callback)
    {
        isChangingPosition = true;

        float distanceToTarget = Vector3.Distance(startPosition, targetPosition);
        float transitionTime   = distanceToTarget / characterConfig.positionChangeSpeed;

        float deltaValue = 0;
        while (deltaValue < 1.0f)
        {
            deltaValue               += Time.deltaTime / transitionTime;
            model.transform.position =  Vector3.Lerp(startPosition, targetPosition, deltaValue);

            yield return null;
        }

        callback?.Invoke();
        isChangingPosition = false;
    }

    private bool CanChangePosition(bool isMoveRight)
    {
        return isMoveRight ? currentPositionIndex + 1 < characterConfig.positionStates.Length : currentPositionIndex - 1 >= 0;
    }

    private void TryToStopCoroutine(IEnumerator coroutine)
    {
        if (coroutine != null)
            model.StopCoroutine(coroutine);
    }
}