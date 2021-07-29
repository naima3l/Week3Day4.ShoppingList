using System;
using System.Collections.Generic;

namespace Week3Day4.ShoppingList
{
    internal class Menu
    {
        //Sviluppare una console app che permetta ad un utente di acquistare prodotti su un e-commerce.



        //I prodotti disponibili sono:
        //- prodotti alimentari:
        //codice prodotto
        //prezzo
        //descrizione
        //data di scadenza
        //- prodotti di abbigliamento
        //codice prodotto
        //prezzo
        //descrizione
        //taglia
        //brand
        //- prodotti elettronica
        //codice prodotto
        //prezzo
        //descrizione
        //marca
        //modello



        //Un utente può:
        //vedere tutti i prodotti per categoria
        //vedere tutti i prodotti per categoria con prezzo <= al prezzo inserito
        //vedere gli alimenti con una data di scadenta >= alla data inserita
        //vedere l'abbigliamento con taglia uguale alla taglia inserita
        //vedere gli elettrodomestici della marca inserita.



        //Facoltativo. -> ogni volta che l'utente visualizza una lista di prodotti,
        //gli viene chiesto se e quale prodotto vuole aggiungere al carrello
        //Se sceglie un prodotto viene aggiunto al carrello.
        //Quindi tra le opzioni ci sarà: Procedi agli acquisti.
        //Verrà stampato a video il totale dei prodotti nel carrello

        internal static ProductRepository pr = new ProductRepository();
        internal static FoodProductRepository fpr = new FoodProductRepository();
        internal static ClothingProductRepository cpr = new ClothingProductRepository();
        internal static ElectronicsProductRepository epr = new ElectronicsProductRepository();
        internal static void Start()
        {
            bool check = false;
            int choice;

            Console.WriteLine("Benvenuto in negozio!");
            do
            {
                Console.WriteLine("\nInserisci 1 per vedere tutti i prodotti \nInserisci 2 per vedere tutti i prodotti per categoria con prezzo <= al prezzo inserito  \nInserisci 3 per vedere gli alimenti con una data di scadenta >= alla data inserita  \nInserisci 4 per vedere l'abbigliamento con taglia uguale alla taglia inserita \nInserisci 5 per vedere gli elettrodomestici della marca inserita \nInserisci 0 per uscire");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.WriteLine("Scelta non valida! Riprova.");
                }

                switch (choice)
                {
                    case 1: //vedere tutti i prodotti
                        ShowProducts();
                        break;
                    case 2: //tutti i prodotti per categoria con prezzo <= al prezzo inserito
                        ShowProductsByPrice();
                        break;
                    case 3: //Inserisci 3 per vedere gli alimenti con una data di scadenta >= alla data inserita
                        ShowFoodProductsByExpiratiion();
                        break;
                    case 4: //vedere l'abbigliamento con taglia uguale alla taglia inserita
                        ShowClothingBySize();
                        break;
                    case 5: //vedere gli elettrodomestici della marca inserita
                        ShowElectronicsByBrand();
                        break;
                    case 0:
                        Console.WriteLine("Ciao ciao!");
                        check = true;
                        break;
                }


            } while (check == false);
        }

        private static void ShowProducts()
        {
            List<Product> products = pr.Fetch();
            List<Product> p = pr.FetchCart(); //carrello
            decimal tot = 0;

            int scelta;
            bool c = false;
            foreach (var x in products)
            {
                Console.WriteLine(x.Print());
            }

            do
            {
                Console.WriteLine("Vuoi inserire uno di questi prodotti nel carrello? Premi 1 per sì, 0 altrimenti");

                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 1)
                {
                    Console.WriteLine("Riprova con un opzione valida!");
                }

                if (scelta == 0)
                {
                    c = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Inserisci il codice del prodotto che vuoi inserire");

                    string cod = Console.ReadLine();

                    while (cod == null)
                    {
                        Console.WriteLine("Inserisci un codice valido!");
                    }
                    int res = pr.AddProductToCart(cod);
                    if (res < 0)
                    {
                        Console.WriteLine("Hai inserito un codice sbagliato");
                    }
                    else
                    {
                        foreach (var y in p)
                        {
                            Console.WriteLine(y.Print());
                        }
                        tot = pr.TotalCart(p);
                        Console.WriteLine($"Il totale del carrello è : {tot}");
                    }
                }

            } while (c == false);
        }

        private static void ShowElectronicsByBrand()
        {
            Console.WriteLine("Inserisci il brand per cui vuoi visualizzare il prodotto di elettronica");
            EnumBrandE b = GetBrand();


            List<ElectronicsProduct> epBrand = epr.ShowElectronicsByBrand(b);
            if (epBrand.Count >= 1)
            {
                Console.WriteLine($"\nI prodotti d'elettronica con brand {b} sono : \n");
                foreach (var e in epBrand)
                {
                    Console.WriteLine(e.Print());
                }
            }
            else Console.WriteLine($"Nessun prodotto d'elettronica ha brand {b}");
        }

        private static EnumBrandE GetBrand()
        {
            Console.WriteLine($"Premi {(int)EnumBrandE.Bosch} per scegliere {EnumBrandE.Bosch}");
            Console.WriteLine($"Premi {(int)EnumBrandE.Dyson} per scegliere {EnumBrandE.Dyson}");
            Console.WriteLine($"Premi {(int)EnumBrandE.Motorola} per scegliere {EnumBrandE.Motorola}");
            Console.WriteLine($"Premi {(int)EnumBrandE.Phillips} per scegliere {EnumBrandE.Phillips}");
            Console.WriteLine($"Premi {(int)EnumBrandE.Samsung} per scegliere {EnumBrandE.Samsung}");

            int b;
            while (!int.TryParse(Console.ReadLine(), out b) || b < 0 || b > 4)
            {
                Console.WriteLine("Scelta non corretta, riprova");
            }

            return (EnumBrandE)b;
        }

        private static void ShowClothingBySize()
        {
            Console.WriteLine("Inserisci la taglia per cui vuoi visualizzare l'abbigliamento (XS, S, M, L, XL, XXL, XXXL)");
            EnumSize s = GetSize();


            List<ClothingProduct> cpSize = cpr.ShowClothingBySize(s);
            if (cpSize.Count >= 1)
            {
                Console.WriteLine($"\nI prodotti d'abbigliamento con taglia {s} sono : \n");
                foreach (var c in cpSize)
                {
                    Console.WriteLine(c.Print());
                }
            }
            else Console.WriteLine($"Nessun prodotto d'abbigliamento ha taglia {s}");
        }

        internal static EnumSize GetSize()
        {
            Console.WriteLine($"Premi {(int)EnumSize.XS} per scegliere {EnumSize.XS}");
            Console.WriteLine($"Premi {(int)EnumSize.S} per scegliere {EnumSize.S}");
            Console.WriteLine($"Premi {(int)EnumSize.M} per scegliere {EnumSize.M}");
            Console.WriteLine($"Premi {(int)EnumSize.L} per scegliere {EnumSize.L}");
            Console.WriteLine($"Premi {(int)EnumSize.XL} per scegliere {EnumSize.XL}");
            Console.WriteLine($"Premi {(int)EnumSize.XXL} per scegliere {EnumSize.XXL}");
            Console.WriteLine($"Premi {(int)EnumSize.XXXL} per scegliere {EnumSize.XXXL}");

            int s;
            while (!int.TryParse(Console.ReadLine(), out s) || s < 0 || s > 6)
            {
                Console.WriteLine("Scelta non corretta, riprova");
            }

            return (EnumSize)s;
        }
        private static void ShowFoodProductsByExpiratiion()
        {
            Console.WriteLine("Inserisci la data per cui vuoi visualizzare gli alimenti con una data di scadenta >= alla data inserita");
            DateTime date = new DateTime();
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Inserisci una data valida!");
            }

            List<FoodProduct> fpExpiration = fpr.ShowFoodProductsByExpiratiion(date);
            if (fpExpiration.Count >= 1)
            {
                Console.WriteLine("\nI prodotti alimentari con data >= a quella inserita sono : \n");
                foreach (var fe in fpExpiration)
                {
                    Console.WriteLine(fe.Print());
                }
            }
            else Console.WriteLine("Nessun prodotto alimentare ha data >= a quella inserita");
        }

        private static void ShowProductsByPrice()
        {
            int scelta;
            Console.WriteLine("Di quale categoria di prodotti vuoi vedere i prodotti con prezzo <= a quello inserito?");
            Console.WriteLine("Inserisci il numero corrispondente alla categoria");
            Console.WriteLine("1. Alimentari \n2. Abbigliamento \n3. Elettronica\n");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3)
            {
                Console.WriteLine("Scelta errata. Riprova!");
            }

            Console.WriteLine("Inserisci prezzo");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.WriteLine("Inserisci un prezzo valido!");
            }

            switch (scelta)
            {
                case 1: //food
                    List<FoodProduct> fpPrice = fpr.ShowFoodProductByPrice(price);
                    if (fpPrice.Count >= 1)
                    {
                        Console.WriteLine("\nI prodotti alimentari con prezzo <= di quello inserito sono : \n");
                        foreach (var fp in fpPrice)
                        {
                            Console.WriteLine(fp.Print());
                        }
                    }
                    else Console.WriteLine("Nessun prodotto alimentare ha prezzo <= di quello inserito");
                    break;
                case 2: //clothing
                    List<ClothingProduct> cpPrice = cpr.ShowClothingProductByPrice(price);
                    if (cpPrice.Count >= 1)
                    {
                        Console.WriteLine("\nI prodotti di abbigliamento con prezzo <= di quello inserito sono : \n");
                        foreach (var cp in cpPrice)
                        {
                            Console.WriteLine(cp.Print());
                        }
                    }
                    else Console.WriteLine("Nessun prodotto di abbigliamento ha prezzo <= di quello inserito");
                    break;
                case 3: //electronics
                    List<ElectronicsProduct> epPrice = epr.ShowElectronicsProductByPrice(price);
                    if (epPrice.Count >= 1)
                    {
                        Console.WriteLine("\nI prodotti di elettronica con prezzo <= di quello inserito sono : \n");
                        foreach (var ep in epPrice)
                        {
                            Console.WriteLine(ep.Print());
                        }
                    }
                    else Console.WriteLine("Nessun prodotto di elettronica ha prezzo <= di quello inserito");
                    break;
            }


        }
    }
}