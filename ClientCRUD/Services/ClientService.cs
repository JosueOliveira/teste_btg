using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Exceptions;
using ClientCRUD.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ClientCRUD.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientValidation _clientValidation;

        public ClientService(IClientRepository clientRepository, IClientValidation clientValidation)
        {
            this._clientRepository = clientRepository;
            this._clientValidation = clientValidation;
        }

        public void SaveClient(ClientModel client)
        {
            var errors = this._clientValidation.Validate(client);
            if (errors.Any())
            {
                throw new NotificationsExceptions(errors);
            }

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

        public int NextIdClient()
        {
            return _clientRepository.NextId();
        }
    }
}
