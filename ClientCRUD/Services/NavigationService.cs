using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;
using ClientCRUD.Views.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Services;
public class NavigationService : INavigationService
{
    private Window _currentWindow;
    public Task OpenClientDetail(Window window)
    {
        _currentWindow = window;
        Application.Current?.OpenWindow(window);
        return Task.CompletedTask;
    }
    public void CloseModal()
    {
        if (_currentWindow != null)
        {
            Application.Current?.CloseWindow(_currentWindow);
            _currentWindow = null;
        }
    }   
}
