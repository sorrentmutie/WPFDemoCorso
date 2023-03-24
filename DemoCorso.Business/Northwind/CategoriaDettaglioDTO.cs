namespace DemoCorso.Business.Northwind;

public class CategoriaDettaglioDTO
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descrizione { get; set; }

    public List<ProdottoDettaglioDTO>? Prodotti { get; set; } 
}
