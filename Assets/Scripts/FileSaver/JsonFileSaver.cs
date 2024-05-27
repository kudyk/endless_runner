using UnityEngine;

public class JsonFileSaver : FileSaverBase
{
    public override void SaveDataToFile<TData>(TData data, string filePath) where TData : class
    {
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(filePath, json);
    }

    public override TData LoadDataFromFile<TData>(string filePath) where TData : class
    {
        if (!System.IO.File.Exists(filePath))
            return null;

        string json = System.IO.File.ReadAllText(filePath);
        return JsonUtility.FromJson<TData>(json);
    }
}