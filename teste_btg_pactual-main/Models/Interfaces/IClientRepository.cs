using ClientCRUD.Models.Entities;

namespace ClientCRUD.Models.Interfaces
{
    public interface IClientRepository
    {
        void Insert(ClientModel client);
        void Delete(ClientModel client);
        void Update(ClientModel client);
        bool Exists(int Id);
        List<ClientModel> GetAll();
        int NextId();
    }
}
