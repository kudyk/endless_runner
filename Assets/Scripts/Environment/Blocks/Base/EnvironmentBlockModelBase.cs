using UnityEngine;
using Zenject;

public abstract class EnvironmentBlockModelBase : MonoBehaviour
{
    public abstract float UpperEdgePosition { get; }
    public abstract void Init(Vector3 position, bool withoutItems = false);
    public abstract void Move(float movementSpeed);
    public abstract void Deinit();
}

public class EnvironmentBlocksPool : MonoMemoryPool<Vector3, bool, EnvironmentBlockModelBase>
{
    protected override void Reinitialize(Vector3 p1, bool p2, EnvironmentBlockModelBase item)
    {
        item.Init(p1, p2);
    }

    protected override void OnDespawned(EnvironmentBlockModelBase item)
    {
        item.Deinit();
        base.OnDespawned(item);
    }
}