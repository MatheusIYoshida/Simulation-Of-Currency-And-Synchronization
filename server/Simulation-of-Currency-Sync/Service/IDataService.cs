namespace Simulation_of_Currency_Sync.Service;


public interface IDataService
{
    public List<T> LoadData<T>(string filePath);
    public void SaveData<T>(string filePath, List<T> data);
}
