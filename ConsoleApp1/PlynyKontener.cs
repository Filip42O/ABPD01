namespace ConsoleApp1;

public class PlynyKontener : Kontener, IHazardNotifier
{
    private static int _numer = 0;

    public bool CzyNiebezpieczny { get; set; }
    
    public PlynyKontener(double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc)
        : base(wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc, "Kon-L-"+(++_numer))
    {
        
    }

    public  void Zaladuj(double masaDoZaladunku, bool czyNiebezpieczny)
    {
        
        double nowaMaksymalnaLadownosc = 0;
        if (czyNiebezpieczny)
        {
            nowaMaksymalnaLadownosc = 0.5 * MaksymalnaLadownosc;
        }
        else
        {
            nowaMaksymalnaLadownosc = 0.9 * MaksymalnaLadownosc;
        }

        if (masaDoZaladunku > nowaMaksymalnaLadownosc)
        {
            string tresc = "bezpiecznego";
            if(czyNiebezpieczny) tresc = "niebezpiecznego";
            NotifyHazard("Próba przekroczenia maksymalnej ładowności dla "+tresc+" ladunku w kontenerze ", NumerSeryjny);
        }

        if (masaDoZaladunku > MaksymalnaLadownosc)
        {
            throw new OverfillException();
        }
        
        CzyNiebezpieczny = czyNiebezpieczny;
        Masa += masaDoZaladunku;
        
    }

    public void NotifyHazard(string tresc, string numerSeryjny)
    {
        Console.WriteLine(tresc+" "+numerSeryjny);
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine("Niebezpieczny ładunek: "+ (CzyNiebezpieczny ? "Tak" : "Nie")+"\n\n\n");
    }
}