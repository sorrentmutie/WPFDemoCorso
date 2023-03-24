using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DemoCorso.Business.Northwind;

public class CategoriaDTO: INotifyPropertyChanged
{
    public int Id { get; set; }
    private string? nome;
    public string? Nome
    {
        get { return nome; }
        set
        {
            if (value != nome)
            {
                nome = value;
                NotifyPropertyChanged();
            }
        }
    }
    public int NumeroProdotti { get; set; }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public event PropertyChangedEventHandler? PropertyChanged;
}
