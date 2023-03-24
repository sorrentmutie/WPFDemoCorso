using DemoCorso.Business.Northwind;
using DemoCorso.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoCorso.ViewModels;

public class MainWindowViewModel: BaseViewModel
{
    private readonly INorthwindData northwindData;


    public RelayCommand CaricaCommand { get; set; }
    public RelayCommand AggiungiCommand { get; set; }
    public RelayCommand DettaglioCommand { get; set; }

    public MainWindowViewModel(INorthwindData northwindData)
    {
        this.northwindData = northwindData;
        CaricaCommand = new RelayCommand(Carica);
        AggiungiCommand = new RelayCommand(Aggiungi);
        DettaglioCommand = new RelayCommand(Dettaglio);
        // LoadData().Wait();
    }

    private async void Dettaglio()
    {
        var details = await northwindData.EstraiCategoriaPerIdAsync(2);
        await northwindData.ModificaCategoria(new CategoriaDTO { Id = 2, Nome = "XCatXCat" });
        await LoadData();
    }

    private async void Aggiungi()
    {
        await northwindData.CreaCategoriaAsync(new CategoriaCreaDTO
        {
            Nome = "data binding 3",
            Descrizione = "lezione su MVVM"
        });
        await LoadData();
    }

    private async void Carica()
    {
        await LoadData();
    }

    CategoriaDTO? categoriaSelezionata;
    public CategoriaDTO? CategoriaSelezionata
    {
        get { return categoriaSelezionata; }
        set
        {
            categoriaSelezionata = value;
            NotifyPropertyChanged();
        }
    }

    public ObservableCollection<CategoriaDTO> Categorie { get; set; }
           = new();

    private Task LoadData()
    {
        Categorie.Clear();
        var categorie = northwindData.EstraiCategorie();
        foreach (var categoria in categorie)
        {
            Categorie.Add(categoria);
        }
        return Task.CompletedTask;
       // return (await northwindData.EstraiCategorieAsync()).ToList();
    }

   

}
