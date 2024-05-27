public class ObstacleItemView : InteractableItemViewBase
{
    public override void Init()
    {
        gameObject.SetActive(true);
    }

    public override void Deinit()
    {
        gameObject.SetActive(false);
    }
}