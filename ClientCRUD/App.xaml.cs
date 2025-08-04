using ClientCRUD.Views.Client;

namespace ClientCRUD
{
    public partial class App : Application
    {
        public App(ClientListPage clientListPage)
        {
            InitializeComponent(); 
            MainPage = new NavigationPage(clientListPage);
        } 
    }
}