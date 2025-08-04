namespace ClientCRUD.Models.Interfaces
{
    public interface IDataStore<T>
    {
        void SaveData(List<T> data);
        List<T> LoadData();
    }
}
