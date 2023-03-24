using DemoCorso.Business.Northwind;
using System.Collections.ObjectModel;

namespace DemoCorso.ViewModels;

public class MainWindowViewModel
{
    public ObservableCollection<CategoriaDTO> Categorie { get; set; }
        = new ObservableCollection<CategoriaDTO>();
    public INorthwindData NorthwindData { get; }

    public MainWindowViewModel(INorthwindData northwindData)
    {
        NorthwindData = northwindData;
    }
}
