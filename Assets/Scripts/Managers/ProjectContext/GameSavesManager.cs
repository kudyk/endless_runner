using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSavesManager
{
    private const string SAVE_FILE_NAME = "/save.json";
    private       string saveFilePath   = Application.persistentDataPath + SAVE_FILE_NAME;

    private FileSaverBase fileSaver = null;


    public GameSavesManager(FileSaverBase fileSaver)
    {
        this.fileSaver = fileSaver;
    }

    /// <param name="gameKey">some unique game identifier, which can be used in future for different game subtypes</param>
    public void SaveNewAttempt(DateTime timestamp, int pointsSum, string gameKey = "")
    {
        SaveDataContainer savedData = fileSaver.LoadDataFromFile<SaveDataContainer>(saveFilePath) ?? new SaveDataContainer();

        int lastAttemptID = GetLastAttemptID(savedData.attemptsData, gameKey);
        savedData.attemptsData.Add(new AttemptsSaveData() { attemptID = lastAttemptID + 1, gameKey = gameKey, pointsSum = pointsSum, timestamp = timestamp.ToFileTime() });

        fileSaver.SaveDataToFile(savedData, saveFilePath);
    }

    /// <param name="gameKey">some unique game identifier, which can be used in future for different game subtypes</param>
    public List<AttemptsSaveData> GetSavedProgress(string gameKey = "")
    {
        SaveDataContainer savedData = fileSaver.LoadDataFromFile<SaveDataContainer>(saveFilePath);

        if (savedData == null)
            return new List<AttemptsSaveData>();

        return savedData.attemptsData.Where(x => x.gameKey == gameKey).ToList();
    }


    private int GetLastAttemptID(List<AttemptsSaveData> attemptsData, string key)
    {
        if (attemptsData.Count == 0)
            return 0;

        AttemptsSaveData[] saveDataByKey = attemptsData.Where(x => x.gameKey == key).ToArray();
        if (saveDataByKey.Length == 0)
            return 0;

        return saveDataByKey.Max(x => x.attemptID);
    }
}

[Serializable]
public class SaveDataContainer
{
    public List<AttemptsSaveData> attemptsData = new List<AttemptsSaveData>();
}

[Serializable]
public record AttemptsSaveData
{
    public string gameKey;
    public int    attemptID;
    public int    pointsSum;
    public long   timestamp;
}