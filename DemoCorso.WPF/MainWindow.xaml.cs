using DemoCorso.Business;
using DemoCorso.Business.Northwind;
using DemoCorso.Data;
using DemoCorso.Data.Northwind;
using DemoCorso.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoCorso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly IStudentsData studentsData;
        //private readonly INorthwindData northwindData;
        //public ObservableCollection<CategoriaDTO> Categorie { get; set; }
        //     = new();

        public MainWindow(INorthwindData northwindData)
          //  IStudentsData studentsData, )
        {
            //this.studentsData = studentsData;
            //this.northwindData = northwindData;
            InitializeComponent();
            //var categorie = northwindData.EstraiCategorie();
            //foreach (var categoria in categorie)
            //{
            //    Categorie.Add(categoria);
            //}
            DataContext = new MainWindowViewModel(northwindData);

        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    await LoadData();
        //}

        private async void Dettaglio(object sender, RoutedEventArgs e)
        {
            //var details = await northwindData.EstraiCategoriaPerIdAsync(2);
            //// await northwindData.ModificaCategoria(new CategoriaDTO { Id = 2, Nome = "CatCat" });
            //// await northwindData.CancellaCategoria(1021);
            //await LoadData();
        }

        //private async void Aggiungi(object sender, RoutedEventArgs e)
        //{
        //    //await northwindData.CreaCategoriaAsync(new CategoriaCreaDTO
        //    //{
        //    //    Nome = "data binding",
        //    //    Descrizione = "lezione su ef core"
        //    //});
        //    //await LoadData();
        //}

        //private async Task LoadData()
        //{
        //    //Categorie.Clear();
        //    //var categorie = await northwindData.EstraiCategorieAsync();
        //    //foreach (var categoria in categorie)
        //    //{
        //    //    Categorie.Add(categoria);
        //    //}
        //}

    }
}
