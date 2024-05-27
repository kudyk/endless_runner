using Zenject;

public class ObstacleItemModel : InteractableItemModelBase
{
    protected override void ProcessInteraction()
    {
        signalBus.Fire<InteractedWithObstacleSignal>();
    }

    public class Pool : MonoMemoryPool<ObstacleItemModel>
    {
        protected override void Reinitialize(ObstacleItemModel itemModel)
        {
            itemModel.Init();
        }

        protected override void OnDespawned(ObstacleItemModel itemModel)
        {
            itemModel.Deinit();
            base.OnDespawned(itemModel);
        }
    }
}