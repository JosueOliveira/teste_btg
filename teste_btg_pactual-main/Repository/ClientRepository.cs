using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;

namespace ClientCRUD.Repository;
internal class ClientRepository : IClientRepository
{
    private readonly IDataStore<ClientModel> _dataStore;
    private readonly List<ClientModel> _clients;
    public ClientRepository(IDataStore<ClientModel> dataStore)
    {
        _dataStore = dataStore;
        _clients = _dataStore.LoadData();
    }

    public void Insert(ClientModel client)
    {
        _clients.Add(client);
        UpdateData();
    }

    public void Update(ClientModel client)
    {
        var index = _clients.FindIndex(x => x.Id == client.Id);
        if(index >= 0)
        {
            _clients[index] = client;
            UpdateData();
        } 
    }

    public void Delete(ClientModel client)
    {
        var clientRemove = _clients.Find(x => x.Id == client.Id);
        if (clientRemove != null)
        {
            _clients.Remove(clientRemove);
            UpdateData();
        }
    } 
    public bool Exists(int Id)
    {
        return _clients.FindIndex(x => x.Id == Id) >= 0;
    }

    public void UpdateData()
    {
        _dataStore.SaveData(_clients);  
    }

    public int NextId()
    {
        return  _clients.Count == 0 ? 1 : _clients.Max(x => x.Id) + 1;
    }

    public List<ClientModel> GetAll()
    {
        return new List<ClientModel>(_clients);
    }

   
}
