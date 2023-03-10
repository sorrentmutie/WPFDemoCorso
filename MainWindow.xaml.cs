using DemoCorso.Business;
using DemoCorso.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly IGestioneOrdini? gestioneOrdine = null;
        private readonly IConfiguration configuration;

        public ObservableCollection<Student>? Students { get; set; }



        // private GestioneOrdini? gestioneOrdine = null;
        public MainWindow(IGestioneOrdini gestioneOrdine, IConfiguration configuration)
        {
            this.gestioneOrdine = gestioneOrdine;
            this.configuration = configuration;
            InitializeComponent();
            // myStackPanel.DataContext = new MyFakeData();
            var data = new MyFakeData();
            Students = new ObservableCollection<Student>();
            Students = data.ObservableStudents;
            //myListBox.DataContext = Students;

            // IGestioneNotifiche gestioneNotifiche = new GestioneNotificheMock();
            // gestioneOrdine = new GestioneOrdini(gestioneNotifiche);
        }

        private void InviaOrdine(object sender, RoutedEventArgs e)
        {
            var valore = configuration["Prova"];

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

            Students.Add(new Student { Id = 4, Name = "Maria" });

            //var myData = (MyFakeData)myStackPanel.DataContext;
            //if(myData != null && myData.Students != null)
            //{
            //    myData.ObservableStudents.Add(new Student { Id = 4, Name = "Maria" });
            //   // myData.Students.Add(new Student { Id = 4, Name = "Maria" });
            //}

        }
    }
}
