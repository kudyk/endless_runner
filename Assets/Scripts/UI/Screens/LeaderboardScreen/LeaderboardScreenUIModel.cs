using System.Collections.Generic;
using System.Linq;

public class LeaderboardScreenUIModel : LeaderboardScreenUIModelBase
{
    public override void OnShoved(bool isVisible)
    {
        base.OnShoved(isVisible);

        if (isVisible)
            ShowBestScores();
    }

    private void ShowBestScores()
    {
        List<AttemptsSaveData> savedAttempts = savesManager.GetSavedProgress();
        AttemptsSaveData[]     bestScores    = savedAttempts.OrderByDescending(x => x.pointsSum).ToArray();

        View.ShowBestScores(bestScores);
    }
}