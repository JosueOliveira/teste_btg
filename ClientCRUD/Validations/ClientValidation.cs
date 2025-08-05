using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;
using ClientCRUD.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Validations;
public class ClientValidation : IClientValidation
{
    public readonly string clientName = "Nome é obrigatório.";
    public IReadOnlyList<string> Validate(ClientModel client)
    {        

        var errors = new List<string>();

        if (client == null)
        {
            errors.Add("Cliente não definido.");
            return errors;
        }            

        if (string.IsNullOrWhiteSpace(client.Name))
            errors.Add(clientName);

        if (string.IsNullOrWhiteSpace(client.LastName))
            errors.Add("Sobrenome é obrigatório.");

        if (string.IsNullOrWhiteSpace(client.Address))
            errors.Add("Endereço é obrigatório.");

        if (client.Age <= 0)
            errors.Add("Idade deve ser maior que zero.");

        if (client.Age > 100)
            errors.Add("Idade não pode ser maior que 100.");

        return errors;
    }
}
