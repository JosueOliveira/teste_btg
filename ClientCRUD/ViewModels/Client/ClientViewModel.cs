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
    public ClientViewModel(IClientService clientService)
    {
        _clientService = clientService;
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
        AddClient();
    }

    [RelayCommand]
    public async Task Cancel()
    {
        CloseModal();
    }

    [RelayCommand]
    private async Task Delete(ClientModel client)
    {
        if (!await DisplayAlert.ConfirmAlert($"Deseja apagar o cliente {client.DefaultProperty}?"))
            return;

        DeleteClient(client);
    }

    [RelayCommand]
    private async Task Edit(ClientModel client)
    {
        EditClient(client);
    }
    #endregion

    #region CRUD
    private async void AddClient()
    {
        try
        {
            _clientService.SaveClient(this.Client);
            AfterSave();
        }
        catch (Exception e)
        {
            HasError = true;
            ErrorMessage = e.Message;            
        }
    }

    private async void EditClient(ClientModel client)
    {
        try
        {
            OpenClientDetailPage(CloneClient(client));
        }
        catch (Exception e)
        {
            DisplayAlert.ShowAlert($"Não foi possível editar este cliente!!{Environment.NewLine}{e.Message}");
        }
    }

    private async void DeleteClient(ClientModel client)
    {
        try
        {
            _clientService.DeleteClient(client);
            LoadClients();
        }
        catch (Exception e)
        {
            DisplayAlert.ShowAlert($"Não foi possível excluir este cliente!!{Environment.NewLine}{e.Message}");
        }
    }
    #endregion

    #region Métodos Auxiliares
    private void Initiliazer()
    {
        InitClient();
        LoadClients();
    }
    private void AfterSave()
    {
        LoadClients();
        CloseModal();
    }
    public void InitClient()
    {
        Client = new ClientModel(); 
        HasError = false;
        ErrorMessage = string.Empty;
    }
    private void LoadClients()
    { 
        Clients = new ObservableCollection<ClientModel>(_clientService.GetAllClients());
    }
    private async void OpenClientDetailPage(ClientModel editClient = null)
    {
        if (editClient != null)
            this.Client = editClient;
        else
            this.Client.Id = _clientService.NextIdClient();


        var clientDetail = new ClientDetailPage(this);
        _window = new Window(clientDetail);
        Application.Current?.OpenWindow(_window);
    }
    private async void CloseModal()
    {
        InitClient(); 
        Application.Current?.CloseWindow(_window);
    }
    private ClientModel CloneClient(ClientModel client)
    {
        return new ClientModel
        {
            Id = client.Id,
            Name = client.Name,
            LastName = client.LastName,
            Age = client.Age,
            Address = client.Address
        };
    }
     
    #endregion 
}
