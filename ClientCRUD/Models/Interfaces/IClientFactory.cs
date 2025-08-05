using ClientCRUD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Models.Interfaces;
public interface IClientFactory
{
    ClientModel CreateNew(int id = 0);
    ClientModel Clone(ClientModel model);   
}
