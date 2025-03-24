
using ConsoleApp1;

//Tworzenie kontenerów
ChlodniaKontener chlodnia1 = new ChlodniaKontener(280, 2200, 606, 29000);

GazKontener gaz1= new GazKontener(280, 2200, 606, 29000);

PlynyKontener plyny1 = new PlynyKontener(280, 2200, 606, 29000);

//załadunek kontenerów
chlodnia1.Zaladuj(29000, "Bananas");
gaz1.Zaladuj(29000, 3);
plyny1.Zaladuj(29000, true);



//info o kontenerach
chlodnia1.Info();
gaz1.Info();
plyny1.Info();



//tworzenie kontenerowców
Kontenerowiec kontenerowiec1 = new Kontenerowiec(15, 1000, 1000, "Sputnik");
Kontenerowiec kontenerowiec2 = new Kontenerowiec(15, 1000, 1000, "Rybitwa");


//załadunek pojedynczego kontenera
kontenerowiec1.Zaladuj(chlodnia1);

//załadunek listy kontenerów
List<Kontener> listaKontenerow = new List<Kontener>();
listaKontenerow.Add(gaz1);
listaKontenerow.Add(plyny1);
kontenerowiec1.Zaladuj(listaKontenerow);




//info o kontenerowcu
kontenerowiec1.Info();


//usuwanie kontenera z kontenerowca
kontenerowiec1.usunKontener("Kon-G-1");
kontenerowiec1.Info();

//rozładunek kontenera
gaz1.Rozladuj();
gaz1.Info();



//zamiana kontenera na statku na inny
kontenerowiec1.zamienKontenery("Kon-C-1", gaz1);
kontenerowiec1.Info();



//przeniesienie kontenera między statkiami
kontenerowiec1.PrzeniesKontenerMiedzyStatkami("Kon-G-1", kontenerowiec2);
kontenerowiec1.Info();
kontenerowiec2.Info();
