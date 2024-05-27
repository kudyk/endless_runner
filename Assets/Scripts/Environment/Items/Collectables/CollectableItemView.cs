using UnityEngine;

public class CollectableItemView : InteractableItemViewBase
{
    [SerializeField] private CollectableType typeRepresentation = CollectableType.NONE;

    public CollectableType TypeRepresentation => typeRepresentation;


    public override void Init()
    {
        gameObject.SetActive(true);
    }

    public override void Deinit()
    {
        gameObject.SetActive(false);
    }
}