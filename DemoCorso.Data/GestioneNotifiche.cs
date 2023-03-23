namespace DemoCorso.Data;

public  class GestioneNotifiche: IGestioneNotifiche
{
    public int NumeroNotificheInviate { get; set; }
    public bool StatoUltimaNotifica { get; set; }

    public int EstraiNumeroNotificheInviate()
    {
        return NumeroNotificheInviate;
    }

    public bool EstraiStatoUltimaNotificaInviata()
    {
        return StatoUltimaNotifica;
    }

    public bool SpedisciNotifica(int IDCliente, string messaggio )
    {
        Notifica notifica = new Notifica() { IdCliente = IDCliente, Messaggio = messaggio};
        StatoUltimaNotifica = true;
        NumeroNotificheInviate += 1;

        // Spedizione di email
        // SMTP sender properties
        // Creazione codice per mandare messaggio via email
        // 30 righe per mandare mail


        return true;

    }
}
