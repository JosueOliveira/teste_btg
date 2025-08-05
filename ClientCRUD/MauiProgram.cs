using ClientCRUD.Models.DAO;
using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;
using ClientCRUD.Repository;
using ClientCRUD.Services;
using ClientCRUD.Validations;
using ClientCRUD.ViewModels.Client;
using ClientCRUD.Views.Client;
using Microsoft.Extensions.Logging;

namespace ClientCRUD
{
    public static class MauiProgram
    {
        static bool isFirstWindow = true;
        public static MauiApp CreateMauiApp()
        { 
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IDataStore<ClientModel>>(sp =>
            new DataAccess<ClientModel>(ClientModel.tableName)); 
            builder.Services.AddSingleton<ClientViewModel>();
            builder.Services.AddSingleton<ClientListPage>();
            builder.Services.AddTransient<IClientService, ClientService>();
            builder.Services.AddTransient<IClientRepository, ClientRepository>();
            builder.Services.AddTransient<IClientValidation, ClientValidation>();
            
# if WINDOWS
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping("FullscreenWindow", (handler, view) =>
            {
                var window = handler.VirtualView;

                if (isFirstWindow)
                {
                    Platforms.Windows.Services.WindowServices.SetFullScreen(window);
                    isFirstWindow = false;
                }
                else
                {
                    Platforms.Windows.Services.WindowServices.CenterAndResize(window, 1000, 700); 
                }
            });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
