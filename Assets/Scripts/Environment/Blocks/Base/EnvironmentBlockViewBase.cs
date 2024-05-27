using UnityEngine;

public abstract class EnvironmentBlockViewBase : MonoBehaviour
{
    public abstract float                             HalfLenght        { get; }
    public abstract EnvironmentBlockSpawnPointsScheme SpawnPointsScheme { get; }

    public abstract void Init();
    public abstract void Deinit();
}