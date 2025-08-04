using ClientCRUD.Models.Interfaces;
using System.Text.Json;

namespace ClientCRUD.Models.DAO
{
    public class DataAccess<T> : IDataStore<T>
    {
        private readonly string _filePath;

        public DataAccess(string filePath)
        {
            _filePath = filePath;
        }
        public void SaveData(List<T> obj )
        {
            try
            {
                var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {

                throw new IOException($"Erro ao salvar dados em {_filePath}", ex);
            }
        }

        public List<T> LoadData()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<T>();

                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (Exception ex)
            {

                throw new IOException($"Erro ao carragar dados de {_filePath}", ex);
            }
        }
    }
}
