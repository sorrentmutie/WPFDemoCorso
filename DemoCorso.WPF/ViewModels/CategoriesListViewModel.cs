using DemoCorso.Business.Northwind;
using DemoCorso.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DemoCorso.ViewModels;

public class CategoriesListViewModel
{

    private readonly INorthwindData northwindData;
    public RelayCommand DeleteCommand { get; set; }



    public CategoriesListViewModel(INorthwindData northwindData)
    {
        this.northwindData = northwindData;
        LoadData();
        DeleteCommand = new RelayCommand( async () => await OnDelete(), CanExecuteDelete);
    }

    private bool CanExecuteDelete()
    {
        return CategoriaSelezionata != null;
    }

    private async Task OnDelete()
    {
        if(CategoriaSelezionata != null)
        {
            await northwindData.CancellaCategoria(CategoriaSelezionata.Id);
            await LoadDataAsync();
        }
    }


    private CategoriaDTO? categoriaSelezionata;
    public CategoriaDTO? CategoriaSelezionata
    {
        get => categoriaSelezionata;
        set
        {
            categoriaSelezionata = value;
            DeleteCommand.RaiseCanExecuteChanged();
        }
    }



    public ObservableCollection<CategoriaDTO> Categorie { get; set; } = new();

    private void LoadData()
    {
        Categorie.Clear();
        var categorieDb = northwindData.EstraiCategorie();
        foreach (var categoria in categorieDb)
        {
            Categorie.Add(categoria);
        }
    }

    private async Task LoadDataAsync()
    {
        Categorie.Clear();
        var categorieDb = await northwindData.EstraiCategorieAsync();
        foreach (var categoria in categorieDb)
        {
            Categorie.Add(categoria);
        }
    }

}
