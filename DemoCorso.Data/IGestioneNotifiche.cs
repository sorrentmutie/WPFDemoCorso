using System.Dynamic;

namespace DemoCorso.Data;

public interface IGestioneNotifiche
{
    bool SpedisciNotifica(int IDCliente, string messaggio);
    int EstraiNumeroNotificheInviate();
    bool EstraiStatoUltimaNotificaInviata();
}


public class GestioneNotificheMock : IGestioneNotifiche
{
    public int EstraiNumeroNotificheInviate()
    {
        return 5;
    }

    public bool EstraiStatoUltimaNotificaInviata()
    {
        return true;
    }

    public bool SpedisciNotifica(int IDCliente, string messaggio)
    {
        return true;
    }
}


public class GestioneNotificheViaSMS : IGestioneNotifiche
{
    public int EstraiNumeroNotificheInviate()
    {
        throw new NotImplementedException();
    }

    public bool EstraiStatoUltimaNotificaInviata()
    {
        throw new NotImplementedException();
    }

    public bool SpedisciNotifica(int IDCliente, string messaggio)
    {
        throw new NotImplementedException();
    }
}

public class GestioneNotificheViaTelegram : IGestioneNotifiche
{
    public int EstraiNumeroNotificheInviate()
    {
        throw new NotImplementedException();
    }

    public bool EstraiStatoUltimaNotificaInviata()
    {
        throw new NotImplementedException();
    }

    public bool SpedisciNotifica(int IDCliente, string messaggio)
    {
        throw new NotImplementedException();
    }
}