using Zenject;

public class CollectableItemModel : InteractableItemModelBase
{
    protected override void ProcessInteraction()
    {
        CollectableType collectableType = (currentView as CollectableItemView)?.TypeRepresentation ?? CollectableType.NONE;

        signalBus.Fire(new InteractedWithCollectableSignal() { collectableType = collectableType });
        currentView.Deinit();
    }

    public class Pool : MonoMemoryPool<CollectableItemModel>
    {
        protected override void Reinitialize(CollectableItemModel item)
        {
            item.Init();
        }

        protected override void OnDespawned(CollectableItemModel item)
        {
            item.Deinit();
            base.OnDespawned(item);
        }
    }
}