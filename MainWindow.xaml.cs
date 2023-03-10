using DemoCorso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoCorso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GestioneOrdini? gestioneOrdine = null;
        public MainWindow()
        {
            InitializeComponent();
            IGestioneNotifiche gestioneNotifiche = null;
            gestioneOrdine = new GestioneOrdini(gestioneNotifiche);
        }

        private void InviaOrdine(object sender, RoutedEventArgs e)
        {
            
            gestioneOrdine!.CreaOrdine(new Ordine
            {
                Id = 1,
                Data = DateTime.Today,
                ImportoTotale = 1000.0M,
                Cliente = new Cliente
                {
                    Id = 23,
                    RagioneSociale = "Mario Rossi",
                    Indirizzo = "Via del Pino 1"
                }
            });
            var totaleOrdine = gestioneOrdine.NumeroOrdiniCreati;
            ordiniTotali.Content = totaleOrdine;
        }
    }
}
