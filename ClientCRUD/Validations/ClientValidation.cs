using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Validations;
public class ClientValidation : IClientValidation
{
    public void Validate(ClientModel client)
    {
        if (client == null)
            throw new Exception("Cliente não definido.");

        if (string.IsNullOrEmpty(client.Name))
            throw new Exception("Nome obrigatório.");

        if (string.IsNullOrEmpty(client.LastName))
            throw new Exception("Sobrenome obrigatório.");

        if (string.IsNullOrEmpty(client.Address))
            throw new Exception("Endereço obrigatório.");

        if (client.Age <= 0 || client.Age > 100)
            throw new Exception("Idade inválida.");
    }
}
