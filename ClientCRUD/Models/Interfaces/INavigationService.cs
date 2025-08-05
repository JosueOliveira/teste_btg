using ClientCRUD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Models.Interfaces;
public interface INavigationService
{
    Task OpenClientDetail(Window window);
    void CloseModal();
}
