public abstract class EnvironmentTreadmillBase
{
    public abstract void Init(int firstEmptyBlocks = 0);

    public virtual void UpdateTreadmill(float movementSpeed)
    {
        TryToDespawnOldElements();
        TryToSpawnNewElements();
        MoveAllElements(movementSpeed);
    }

    protected abstract void TryToDespawnOldElements();
    protected abstract void TryToSpawnNewElements();
    protected abstract void MoveAllElements(float movementSpeed);
}