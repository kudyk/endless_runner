using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LeaderboardScreenUIView : LeaderboardScreenUIViewBase
{
    [SerializeField] private RectTransform itemsContainer = null;
    [SerializeField] private Button        uiButtonClose  = null;

    private UIScoreItem.Factory itemsFactory = null;
    private List<UIScoreItem>   spawnedItems = new List<UIScoreItem>();


    [Inject]
    public void Construct(UIScoreItem.Factory itemsFactory)
    {
        this.itemsFactory = itemsFactory;
    }

    protected override void OnSubscribe()
    {
        base.OnSubscribe();

        uiButtonClose.onClick.AddListener(CloseSelf);
    }

    protected override void OnUnsubscribe()
    {
        base.OnUnsubscribe();

        uiButtonClose.onClick.RemoveListener(CloseSelf);
    }

    protected override void OnShowed(bool isVisible)
    {
        base.OnShowed(isVisible);

        if (!isVisible)
            DespawnItems();
    }

    public override void ShowBestScores(AttemptsSaveData[] scores)
    {
        SpawnItems(scores);
    }


    private void SpawnItems(AttemptsSaveData[] scores)
    {
        for (int i = 0; i < scores.Length; i++)
        {
            UIScoreItem scoreItem = itemsFactory.Create();
            spawnedItems.Add(scoreItem);

            scoreItem.transform.SetParent(itemsContainer, false);
            scoreItem.Init(i + 1, scores[i]);
        }
    }

    private void DespawnItems()
    {
        foreach (UIScoreItem spawnedItem in spawnedItems)
            Destroy(spawnedItem.gameObject);

        spawnedItems.Clear();
    }
}