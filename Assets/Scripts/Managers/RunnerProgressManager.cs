using UnityEngine;

public class RunnerProgressManager
{
    private ItemProgress regularItems   = null;
    private ItemProgress legendaryItems = null;
    private ItemProgress epicItems      = null;


    public RunnerProgressManager(CollectableItemsConfig collectablesConfig)
    {
        regularItems   = new ItemProgress(collectablesConfig.regularPrice);
        legendaryItems = new ItemProgress(collectablesConfig.legendaryPrice);
        epicItems      = new ItemProgress(collectablesConfig.epicPrice);
    }

    public void IncrementCount(CollectableType collectableType)
    {
        switch (collectableType)
        {
            case CollectableType.REGULAR:
                regularItems.IncrementCount();
                break;
            case CollectableType.LEGENDARY:
                legendaryItems.IncrementCount();
                break;
            case CollectableType.EPIC:
                epicItems.IncrementCount();
                break;
            default:
                Debug.LogError($"Cannot increment type {collectableType})!");
                break;
        }
    }

    public int GetCount(CollectableType collectableType)
    {
        switch (collectableType)
        {
            case CollectableType.REGULAR:
                return regularItems.Count;
            case CollectableType.LEGENDARY:
                return legendaryItems.Count;
            case CollectableType.EPIC:
                return epicItems.Count;
            default:
                return -1;
        }
    }

    public int GetPrice(CollectableType collectableType)
    {
        switch (collectableType)
        {
            case CollectableType.REGULAR:
                return regularItems.GetPrice();
            case CollectableType.LEGENDARY:
                return legendaryItems.GetPrice();
            case CollectableType.EPIC:
                return epicItems.GetPrice();
            default:
                return -1;
        }
    }

    public int GetTotalPrice()
    {
        return regularItems.GetPrice() + legendaryItems.GetPrice() + epicItems.GetPrice();
    }


    private class ItemProgress
    {
        public  int Count { get; private set; }
        private int itemPrice;

        public ItemProgress(int itemPrice, int startCount = 0)
        {
            this.itemPrice = itemPrice;
            Count          = startCount;
        }

        public void IncrementCount()
        {
            Count++;
        }

        public int GetPrice()
        {
            return Count * itemPrice;
        }
    }
}

public enum CollectableType
{
    NONE      = 0,
    REGULAR   = 1,
    LEGENDARY = 2,
    EPIC      = 3,
}