using ClientCRUD.Models.Interfaces;
using ClientCRUD.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Services;
public class AlertService : IAlertService
{
    public Task<bool> ConfirmAsync(string message)
    {
        return DisplayAlert.ConfirmAlert(message);
    }

    public void Show(string message)
    {
        DisplayAlert.ShowAlert(message);    
    }
}
