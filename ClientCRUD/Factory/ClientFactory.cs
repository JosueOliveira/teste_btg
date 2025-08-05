using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Factory;
public class ClientFactory : IClientFactory
{
    public ClientModel CreateNew(int id = 0)
    {
        return new ClientModel
        {
            Id = id,
            Name = string.Empty,
            LastName = string.Empty,
            Address = string.Empty 
        };
    }
    public ClientModel Clone(ClientModel model)
    {
        return new ClientModel
        {
            Id = model.Id,
            Name = model.Name,
            LastName = model.LastName,
            Address = model.Address,
            Age = model.Age
        };
    }   
}
