using DemoCorso.Business.Northwind;
using DemoCorso.Data;
using DemoCorso.Data.Northwind;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly INorthwindData northwindData;
        public ObservableCollection<CategoriaDTO> Categorie { get; set; }
        = new ObservableCollection<CategoriaDTO>();

        public MainWindow(IGestioneOrdini gestioneOrdine, IConfiguration configuration,
            INorthwindData northwindData)
        {
            this.gestioneOrdine = gestioneOrdine;
            this.configuration = configuration;
            this.northwindData = northwindData;
            InitializeComponent();
            DataContext = this;
        }

        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dati = await northwindData.EstraiCategorieAsync();
            if (dati != null)
            {
                foreach (var categoria in dati)
                {
                    Categorie.Add(categoria);
                }
            }
        }
    }
}
