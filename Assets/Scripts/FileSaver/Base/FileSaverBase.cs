public abstract class FileSaverBase
{
    public abstract void SaveDataToFile<TData>(TData data, string filePath) where TData : class;
    public abstract TData LoadDataFromFile<TData>(string filePath) where TData : class;
}