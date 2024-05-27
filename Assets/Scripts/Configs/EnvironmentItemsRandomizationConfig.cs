using UnityEngine;

[CreateAssetMenu(menuName = "Configs/EnvironmentItemsRandomizationConfig", fileName = "EnvironmentItemsRandomizationConfig", order = 0)]
public class EnvironmentItemsRandomizationConfig : ScriptableObject
{
    public float obstaclePerRowChance     = 0.33f;
    public float collectableChancePerCell = 0.5f;
}