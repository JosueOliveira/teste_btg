namespace ClientCRUD.Utilities;
public class DisplayAlert
{
    public async static void ShowAlert(string message)
    {
        await App.Current.MainPage.DisplayAlert("Atenção", message, "OK");
    }

    public async static Task<bool> ConfirmAlert(string message)
    {
        return await App.Current.MainPage.DisplayAlert("Atenção", message, "Sim", "Não");
    }
}
