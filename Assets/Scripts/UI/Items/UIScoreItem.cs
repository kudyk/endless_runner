using System;
using TMPro;
using UnityEngine;
using Zenject;

public class UIScoreItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiTextPlace       = null;
    [SerializeField] private TextMeshProUGUI uiTextGameID      = null;
    [SerializeField] private TextMeshProUGUI uiTextPointsCount = null;
    [SerializeField] private TextMeshProUGUI uiTextTimestamp   = null;


    public void Init(int place, AttemptsSaveData attemptsSaveData)
    {
        uiTextPlace.SetText($"<b>{place.ToString()}</b>");
        uiTextGameID.SetText((attemptsSaveData.attemptID + 1).ToString());
        uiTextPointsCount.SetText(attemptsSaveData.pointsSum.ToString());

        DateTime timestamp = DateTime.FromFileTime(attemptsSaveData.timestamp);
        uiTextTimestamp.SetText(timestamp.ToString("HH:mm dd.MM.yyyy"));
    }

    public class Factory : PlaceholderFactory<UIScoreItem> { }
}