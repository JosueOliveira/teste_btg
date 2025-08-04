using ClientCRUD.Models.Entities;

namespace ClientCRUD.Models.Interfaces
{
    public interface IClientService
    {
        void SaveClient(ClientModel client);
        void DeleteClient(ClientModel client);
        List<ClientModel> GetAllClients();
        int NextIdClient();
    }
}
