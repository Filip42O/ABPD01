namespace ConsoleApp1;

public class ChlodniaKontener : Kontener, IHazardNotifier
{
    private static int _numer = 0;
    public double MinimalnaTemperatura { get; set; }
    public string Produkt { get; set; }
    private Dictionary<string, double> temperaturyProdoktow { get; set; }
    
    
    public ChlodniaKontener(double wysokosc, double wagaWlasna, double glebokosc, double maksymalnaLadownosc)
        : base(wysokosc, wagaWlasna, glebokosc, maksymalnaLadownosc, "Kon-C-"+(++_numer))
    {
        temperaturyProdoktow = new Dictionary<string, double>();
        temperaturyProdoktow.Add("Bananas", 13.3);
        temperaturyProdoktow.Add("Chocolate", 18);
        temperaturyProdoktow.Add("Fish", 2);
        temperaturyProdoktow.Add("Meat", -15);
        temperaturyProdoktow.Add("Ice cream", -18);
        temperaturyProdoktow.Add("Frozen pizza", -30);
        temperaturyProdoktow.Add("Cheese", 7.2);
        temperaturyProdoktow.Add("Sausages", 5);
        temperaturyProdoktow.Add("Butter", 20.5);
        temperaturyProdoktow.Add("Eggs", 19);

        Produkt = "Brak";
        MinimalnaTemperatura = -280;
    }

    public void Zaladuj(double masaDoZaladunku, string ladunek)
    {
        base.Zaladuj(masaDoZaladunku);
        Produkt = ladunek;
        MinimalnaTemperatura = temperaturyProdoktow[Produkt];
    }

    public override void Rozladuj()
    {
        base.Rozladuj();
        Produkt = "Brak";
        MinimalnaTemperatura = -280;

    }

    public void NotifyHazard(string tresc, string numerSeryjny)
    {
        Console.WriteLine(tresc+" "+numerSeryjny);
    }

    public override void Info()
    {
        base.Info();
        Console.WriteLine("Produkt: "+Produkt+"\nTemperatura: "+(MinimalnaTemperatura==-280 ? "Nie ustawiono" : MinimalnaTemperatura)+"\n\n\n");
    }
}