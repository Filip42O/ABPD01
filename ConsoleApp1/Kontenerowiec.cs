namespace ConsoleApp1;

public class Kontenerowiec
{
    public List<Kontener> TransportowaneKontenery { get; set; }
    
    public string Nazwa { get; set; }
    public double Vmax { get; set; }
    public int MaxIloscKontenerow { get; set; }
    public double Ladownosc { get; set; }

    public Kontenerowiec(double vmax, int maxIloscKontenerow, double ladownosc, string nazwa)
    {
        Vmax = vmax;
        MaxIloscKontenerow = maxIloscKontenerow;
        Ladownosc = ladownosc*1000;
        Nazwa = nazwa;
        TransportowaneKontenery = new List<Kontener>();
    }

    public void Zaladuj(Kontener kontener)
    {
        if (TransportowaneKontenery.Count >= MaxIloscKontenerow)
        {
            throw new OverfillException("Statek ma już załadowaną maksymalną ilość kontenerów");
        }
        if (getMasaCalkowitaLadunku()+kontener.Masa>Ladownosc)
        {
            throw new OverfillException("Załadunek anulowany, spowodowałby on przekroczenie ładowności");
        }
        
        TransportowaneKontenery.Add(kontener);

    }

    public void Zaladuj(List<Kontener> kontenery)
    {
        foreach (Kontener k in kontenery)
        {
            Zaladuj(k);
        }
    }

    private double getMasaCalkowitaLadunku()
    {
        double masaCalkowita = 0;
        foreach (Kontener k in TransportowaneKontenery)
        {
            masaCalkowita += k.Masa;
        }
        return masaCalkowita;
    }

    public void usunKontener(String numerSeryjny)
    {
        for (int i = 0; i < TransportowaneKontenery.Count; i++)
        {
            if(numerSeryjny == TransportowaneKontenery[i].NumerSeryjny) TransportowaneKontenery.RemoveAt(i);
        }
    }

    public void zamienKontenery(String numerSeryjny, Kontener kontener)
    {
        for (int i = 0; i < TransportowaneKontenery.Count; i++)
        {
            if(numerSeryjny == TransportowaneKontenery[i].NumerSeryjny) TransportowaneKontenery.RemoveAt(i);
        }
        Zaladuj(kontener);
    }

    public void PrzeniesKontenerMiedzyStatkami(String numerSeryjny, Kontenerowiec kontenerowiec)
    {
        for (int i = 0; i < TransportowaneKontenery.Count; i++)
        {
            if (numerSeryjny == TransportowaneKontenery[i].NumerSeryjny)
            {
                kontenerowiec.Zaladuj(TransportowaneKontenery[i]);
                TransportowaneKontenery.RemoveAt(i);
            }
        }
    }

    public void Info()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("Nazwa: "+Nazwa+"\nvmax: "+Vmax+" węzłów\nMaksymalna ilość kontenerów: "+MaxIloscKontenerow
        +"\nIlość załadowanych kontenerów: "+TransportowaneKontenery.Count+"\nŁadowność: "+Ladownosc+" kg\nMasa ładunku: "+getMasaCalkowitaLadunku()+" kg\nKontenery: ");
        foreach(Kontener k in TransportowaneKontenery) Console.WriteLine(k.NumerSeryjny);
        Console.WriteLine("\n\n\n");
    }
    
    
    
}