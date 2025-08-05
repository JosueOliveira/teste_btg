using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;
using ClientCRUD.Utilities;
using ClientCRUD.Views.Client;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ClientCRUD.ViewModels.Client;
public partial class ClientViewModel : ObservableObject
{
    #region Properties
    private Window _window;
    private readonly IClientService _clientService;
    private readonly INavigationService _navigationService;
    private readonly IAlertService _alertService;
    private readonly IClientFactory _clientFactory;
    [ObservableProperty]
    private ObservableCollection<ClientModel> clients;
    [ObservableProperty]
    private ClientModel client;
    [ObservableProperty]
    private bool hasError;
    [ObservableProperty]
    private string errorMessage;
    #endregion

    #region Builders
    public ClientViewModel(
        IClientService clientService, 
        INavigationService navigationService,
        IAlertService alertService,
        IClientFactory clientFactory)
    {
        _clientService = clientService;
        _navigationService = navigationService;       
        _alertService = alertService;
        _clientFactory = clientFactory;
        Initiliazer();
    }
    #endregion

    #region Commands
    [RelayCommand]
    public async Task NewClient()
    {
        InitClient();
        OpenClientDetailPage();
    }

    [RelayCommand]
    public async Task Add()
    {
        await AddClient();
    }

    [RelayCommand]
    public async Task Cancel()
    {
        await CloseModal();
    }

    [RelayCommand]
    private async Task Delete(ClientModel client)
    {
        if (!await _alertService.ConfirmAsync($"Deseja apagar o cliente {client.DefaultProperty}?"))
            return;

        await DeleteClient(client);
    }

    [RelayCommand]
    private async Task Edit(ClientModel client)
    {
        await EditClient(client);
    }
    #endregion

    #region CRUD
    private async Task AddClient()
    {
        try
        {
            _clientService.SaveClient(this.Client);
            await AfterSave();
        }
        catch (Exception e)
        {
            HasError = true;
            ErrorMessage = e.Message;            
        }
    }

    private async Task EditClient(ClientModel client)
    {
        try
        {
            await OpenClientDetailPage(_clientFactory.Clone(client));
        }
        catch (Exception e)
        {
            _alertService.Show($"Não foi possível editar este cliente!!{Environment.NewLine}{e.Message}");            
        }
    }

    private async Task DeleteClient(ClientModel client)
    {
        try
        {
            _clientService.DeleteClient(client);
            LoadClients();
        }
        catch (Exception e)
        {
            _alertService.Show($"Não foi possível excluir este cliente!!{Environment.NewLine}{e.Message}");            
        }
    }
    #endregion

    #region Métodos Auxiliares
    private void Initiliazer()
    {
        InitClient();
        LoadClients();
    }
    private async Task AfterSave()
    {
        LoadClients();
        await CloseModal();
    }
    public void InitClient()
    {
        Client = _clientFactory.CreateNew(); 
        HasError = false;
        ErrorMessage = string.Empty;
    }
    private void LoadClients()
    { 
        Clients = new ObservableCollection<ClientModel>(_clientService.GetAllClients());
    }
    private async Task OpenClientDetailPage(ClientModel editClient = null)
    {
        if (editClient != null)
            this.Client = editClient;
        else
            this.Client.Id = _clientService.NextIdClient();

        var clientDetail = new ClientDetailPage(this);
        _window = new Window(clientDetail);
        await _navigationService.OpenClientDetail(_window);        
    }
    private async Task CloseModal()
    {
        InitClient();
        _navigationService.CloseModal(); 
    } 
     
    #endregion 
}
