using DemoCorso.Business;
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
        private readonly IStudentsData studentsData;

        public MainWindow(IGestioneOrdini gestioneOrdine, IConfiguration configuration,
            IStudentsData studentsData)
        {
            this.gestioneOrdine = gestioneOrdine;
            this.configuration = configuration;
            this.studentsData = studentsData;
            InitializeComponent();
            DataContext = studentsData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            studentsData.AddStudent();
        }
    }
}
