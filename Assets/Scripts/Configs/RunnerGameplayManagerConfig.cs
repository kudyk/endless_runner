using UnityEngine;

[CreateAssetMenu(menuName = "Configs/RunnerGameplayManagerConfig", fileName = "RunnerGameplayManagerConfig", order = 0)]
public class RunnerGameplayManagerConfig : ScriptableObject
{
    public int   firstEmptyBlocksCount  = 3;
    public float waitSecondsBeforeStart = 2.0f;
    public float movementSpeed          = -10;
}