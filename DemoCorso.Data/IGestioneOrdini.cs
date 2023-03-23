namespace DemoCorso.Data
{
    public interface IGestioneOrdini
    {
        int NumeroOrdiniCreati { get; set; }
        bool CreaOrdine(Ordine ordine);
    }
}