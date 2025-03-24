namespace ConsoleApp1;

public class Kontener
{
    public double Masa { get; set; }
    public double Wysokosc { get; set; }
    public double WagaWlasna { get; set; }
    public double Glebokosc { get; set; }
    public double MaksymalnaLadownosc { get; set; }
    public string NumerSeryjny { get; set; }
    
    
    public Kontener(double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc, string numerSeryjny)
    {
        Masa = wagaWlasna;
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        MaksymalnaLadownosc = maksymalnaLadownosc;
        NumerSeryjny = numerSeryjny;
    }

    public virtual void Zaladuj(double masaDoZaladunku)
    {
        if (masaDoZaladunku > MaksymalnaLadownosc)
        {
            throw new OverfillException();
        }
        Masa += masaDoZaladunku;

    }

    public virtual void Rozladuj()
    {
        Masa = WagaWlasna;
    }

    public virtual void Info()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine("Numer seryjny: "+NumerSeryjny+"\nRodzaj kontenera: "+(NumerSeryjny[4]=='C' ? "Chłodnia" : NumerSeryjny[4]=='G' ? "Gaz" : "Płyny")+
                          "\nMasa całkowita: "+Masa+"kg\nMasa ładunku: "+(Masa-WagaWlasna)+"kg\nMaksymalna ładowność: "+MaksymalnaLadownosc+"kg\nMasa własna: "+WagaWlasna
                          +"kg\nWysokość: "+Wysokosc+"\nGłębokość: "+Glebokosc);

    }
    
    
}