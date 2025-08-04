using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;

namespace ClientCRUD.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public void SaveClient(ClientModel client)
        {
            ValidateClient(client);

            var exists = _clientRepository.Exists(client.Id);

            if(exists)
                _clientRepository.Update(client);
            else
                _clientRepository.Insert(client); 
        }

        public void DeleteClient(ClientModel client)
        {
            if (client == null)
                throw new ArgumentNullException("Cliente não definido.");

            _clientRepository.Delete(client);
        }

        public List<ClientModel> GetAllClients()
        {
            return _clientRepository.GetAll();
        }

        public void ValidateClient(ClientModel client)
        {
            if (client == null)
                throw new Exception("Cliente não definido.");

            if(string.IsNullOrEmpty(client.Name))
                throw new Exception("Nome obrigatório.");

            if (string.IsNullOrEmpty(client.LastName))
                throw new Exception("Sobrenome obrigatório.");

            if (string.IsNullOrEmpty(client.Address))
                throw new Exception("Endereço obrigatório.");

            if (client.Age <= 0 || client.Age > 100)
                throw new Exception("Idade inválida.");
        }

        public int NextIdClient()
        {
            return _clientRepository.NextId();
        }
    }
}
