namespace ConsoleApp1;

public class GazKontener : Kontener, IHazardNotifier
{
    private static int _numer = 0;
    public double Cisnienie { get; set; }
    
    public GazKontener(double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc)
        : base(wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc, "Kon-G-"+(++_numer))
    {
        
    }

    public void Zaladuj(double masaDoZaladunku, double cisnienie)
    {
        base.Zaladuj(masaDoZaladunku);
        Cisnienie = cisnienie;
    }

    public override void Rozladuj()
    {
        Masa = (Masa - WagaWlasna) * 0.05 + WagaWlasna;
        Cisnienie *= 0.05;
    }

    public void NotifyHazard(string tresc, string numerSeryjny)
    {
        Console.WriteLine(tresc+" "+numerSeryjny);
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine("Ciśnienie: "+Cisnienie+" BAR\n\n\n");
    }
}