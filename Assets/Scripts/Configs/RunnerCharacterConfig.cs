using UnityEngine;

[CreateAssetMenu(menuName = "Configs/RunnerCharacterConfig", fileName = "RunnerCharacterConfig", order = 0)]
public class RunnerCharacterConfig : ScriptableObject
{
    public float     positionChangeSpeed;
    public int       defaultPositionIndex;
    public Vector3[] positionStates;
}