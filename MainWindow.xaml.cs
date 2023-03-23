using DemoCorso.Data;
using Microsoft.Extensions.Configuration;
using System.Windows;

namespace DemoCorso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IGestioneOrdini? gestioneOrdine = null;
        private readonly IConfiguration configuration;

        public MainWindow(IGestioneOrdini gestioneOrdine, IConfiguration configuration)
        {
            this.gestioneOrdine = gestioneOrdine;
            this.configuration = configuration;
            InitializeComponent();           
        }       
    }
}
