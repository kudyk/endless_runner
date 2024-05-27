public class HUDScreenUIModel : HUDScreenUIModelBase
{
    public void Update()
    {
        ShowScoresValues();
    }

    private void ShowScoresValues()
    {
        if (progressManager == null)
            return;

        int regularPointsCount   = progressManager.GetPrice(CollectableType.REGULAR);
        int legendaryPointsCount = progressManager.GetPrice(CollectableType.LEGENDARY);
        int epicPointsCount      = progressManager.GetPrice(CollectableType.EPIC);
        int allPointsCount       = progressManager.GetTotalPrice();

        View.UpdateScores(regularPointsCount, legendaryPointsCount, epicPointsCount, allPointsCount);
    }
}