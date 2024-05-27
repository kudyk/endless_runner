using UnityEngine;

[CreateAssetMenu(menuName = "Configs/GameplayPrefabsPathsConfig", fileName = "GameplayPrefabsPathsConfig", order = 0)]
public class GameplayPrefabsPathsConfig : ScriptableObject
{
    public string characterViewDirectory    = string.Empty;
    public string characterModelDirectory   = string.Empty;
    public string environmentBlockDirectory = string.Empty;
    public string obstacleDirectory         = string.Empty;
    public string collectableDirectory      = string.Empty;
}