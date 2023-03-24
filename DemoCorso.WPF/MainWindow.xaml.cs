using DemoCorso.Business;
using DemoCorso.Business.Northwind;
using DemoCorso.Data;
using DemoCorso.Data.Northwind;
using Microsoft.Extensions.Configuration;
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
        private readonly IStudentsData studentsData;
        private readonly INorthwindData northwindData;
        public ObservableCollection<CategoriaDTO> Categorie { get; set; }
             = new();

        public MainWindow(
            IStudentsData studentsData, INorthwindData northwindData)
        {
            this.studentsData = studentsData;
            this.northwindData = northwindData;
            InitializeComponent();
            //var categorie = northwindData.EstraiCategorie();
            //foreach (var categoria in categorie)
            //{
            //    Categorie.Add(categoria);
            //}
            DataContext = this;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var categorie = await northwindData.EstraiCategorieAsync();
            foreach (var categoria in categorie)
            {
                Categorie.Add(categoria);
            }
        }
    }
}
