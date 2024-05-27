using UnityEngine;

[CreateAssetMenu(menuName = "Configs/RunnerEnvironmentTreadmillConfig", fileName = "RunnerEnvironmentTreadmillConfig", order = 0)]
public class RunnerEnvironmentTreadmillConfig : ScriptableObject
{
    public float pointOfDispose     = -20.0f;
    public float pointOfGeneration  = 100.0f;
    public float zeroBlockEdgePoint = -10.0f;
}