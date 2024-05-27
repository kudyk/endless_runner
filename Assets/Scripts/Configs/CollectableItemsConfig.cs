using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CollectableItemsConfig", fileName = "CollectableItemsConfig", order = 0)]
public class CollectableItemsConfig : ScriptableObject
{
    public int regularPrice   = 5;
    public int legendaryPrice = 10;
    public int epicPrice      = 5;
}