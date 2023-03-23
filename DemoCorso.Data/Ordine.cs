namespace DemoCorso.Data;

public class Ordine
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public Cliente? Cliente { get; set; }
    public decimal? ImportoTotale { get; set; }
}
