namespace DemoCorso.Data;

public class Notifica
{
    public int Id { get; set; }
    public string Messaggio { get; set; } = string.Empty;
    public int IdCliente { get; set; }
    public DateTime Data { get; set; }

    public Notifica()
    {
        // Logica per spedire una notifica
        // Creazione di una email
        // Creare una istanza di una classe che si occupi di spedire le email
        Data = DateTime.Now;
    }
}