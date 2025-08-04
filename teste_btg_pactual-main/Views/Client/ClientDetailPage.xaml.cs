using ClientCRUD.ViewModels.Client;

namespace ClientCRUD.Views.Client;

public partial class ClientDetailPage : ContentPage
{
    private readonly ClientViewModel _clientViewMode;
    public ClientDetailPage(ClientViewModel clientViewModel)
    {
        InitializeComponent();   
        BindingContext = clientViewModel;
    }  

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    { 
        ValidateForm();
    }

    private void OnAgeTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;

        if (entry != null && !string.IsNullOrEmpty(entry.Text))         
        {
            string onlyNumbers = new string(entry.Text.Where(char.IsDigit).ToArray());

            if (entry.Text != onlyNumbers)
                entry.Text = onlyNumbers;
        }
       

        ValidateForm();
    }

    private void ValidateForm()
    {
        bool allFilled = !string.IsNullOrWhiteSpace(NameEntry.Text) &&
                         !string.IsNullOrWhiteSpace(LastNameEntry.Text) &&
                         !string.IsNullOrWhiteSpace(AgeEntry.Text) &&
                         !string.IsNullOrWhiteSpace(AddressEntry.Text);

        SaveButton.IsEnabled = allFilled;
    } 


}