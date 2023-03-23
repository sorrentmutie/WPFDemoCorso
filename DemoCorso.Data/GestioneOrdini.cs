namespace DemoCorso.Data;

public class GestioneOrdini : IGestioneOrdini
{
    private readonly IGestioneNotifiche gestioneNotifiche;

    public GestioneOrdini(IGestioneNotifiche gestioneNotifiche)
    {
        this.gestioneNotifiche = gestioneNotifiche;
    }



    public int NumeroOrdiniCreati { get; set; }

    public bool CreaOrdine(Ordine ordine)
    {

        // Logica Business che analizza dei parametri passati in input
        // Scrittura degli ordini nel database

        //var gestioneNotifiche = new GestioneNotifiche();

        if (ordine.Cliente != null)
        {
            gestioneNotifiche.SpedisciNotifica(ordine.Cliente.Id, "");
            NumeroOrdiniCreati += 1;
            return true;
        }
        return false;
    }
}
