using DemoCorso.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Configuration;

namespace DemoCorso
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((h, services) =>
                {
                    services.AddSingleton<IGestioneNotifiche, GestioneNotificheMock>();
                    services.AddSingleton<IGestioneOrdini, GestioneOrdini>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();


            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder!.Build();
            var x = configuration["Prova"];
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            //IGestioneNotifiche gestioneNotifiche = new GestioneNotificheMock();
            //IGestioneOrdini gestioneOrdini = new GestioneOrdini(gestioneNotifiche);
            //var startupWindow = new MainWindow(gestioneOrdini);
            //startupWindow.Show();
            if(AppHost != null) {
                var startupWindow = AppHost.Services.GetRequiredService<MainWindow>();
                startupWindow.Show();
            }


            base.OnStartup(e);
        }

    }

    
}
