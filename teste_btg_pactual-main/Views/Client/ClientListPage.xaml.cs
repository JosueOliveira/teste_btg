using ClientCRUD.ViewModels.Client;

namespace ClientCRUD.Views.Client;

public partial class ClientListPage : ContentPage
{
	public ClientListPage(ClientViewModel viewModel)
	{
		InitializeComponent();  
        BindingContext = viewModel;
	}

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        if (!await Utilities.DisplayAlert.ConfirmAlert("Deseja sair do sistema?"))
            return;

#if WINDOWS
        System.Environment.Exit(0);
#endif
    } 
     
}