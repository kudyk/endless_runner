using UnityEngine;

public class HUDScreenUIView : HUDScreenUIViewBase
{
    [SerializeField] private UITextCount lowPointsCount    = null;
    [SerializeField] private UITextCount mediumPointsCount = null;
    [SerializeField] private UITextCount highPointsCount   = null;
    [SerializeField] private UITextCount totalPointsCount  = null;


    public override void UpdateScores(int lowValue, int mediumValue, int highValue, int totalValue)
    {
        lowPointsCount.ShowCount(lowValue);
        mediumPointsCount.ShowCount(mediumValue);
        highPointsCount.ShowCount(highValue);
        totalPointsCount.ShowCount(totalValue);
    }
}