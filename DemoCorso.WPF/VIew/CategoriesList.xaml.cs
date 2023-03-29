using DemoCorso.Business.Northwind;
using DemoCorso.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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

namespace DemoCorso.VIew
{
    /// <summary>
    /// Logica di interazione per CategoriesList.xaml
    /// </summary>
    public partial class CategoriesList : UserControl
    {
        public CategoriesList()
        {
            InitializeComponent();

           var dataService=  App.AppHost?.Services.GetRequiredService<INorthwindData>();
           if(dataService != null)
           {
                DataContext = new CategoriesListViewModel(dataService);
           }
        }
    }
}
