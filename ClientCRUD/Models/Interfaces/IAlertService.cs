using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Models.Interfaces;
public interface IAlertService
{
    Task<bool> ConfirmAsync(string message);
    void Show(string message);
}
