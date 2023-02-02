using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syst_zarzad_rest
{
    abstract class Functions
    {
        public static void DodawanieDan()
        {

            int dishID = 1;
            bool loop = true;
            while (loop)
            {
                Console.ForegroundColor = ConsoleColor.White;




                Console.WriteLine("Podaj nazwe:");
                string na = Console.ReadLine();
                Console.WriteLine("Podaj opis:");
                string op = Console.ReadLine();
                Console.WriteLine("Podaj Cene:");
                double ce = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Podaj nazwe kategorii do ktorej chcesz dodac danie: Przystawki, Zupy, Dania Glowne");
                string nazwaKategoria = Console.ReadLine();
                Console.WriteLine("Podaj typ dania: Vege, Miesne, Rybne");
                string type = Console.ReadLine();


                if (type == "Miesne")
                {
                    Kategoria k = Kategoria.kategoria.FirstOrDefault(kategoria => kategoria.NazwaKategoria == nazwaKategoria);
                    Menu.danie.Add(new DanieMiesne(dishID, na, op, ce, k));
                }
                else if (type == "Vege")
                {
                    Kategoria k = Kategoria.kategoria.FirstOrDefault(kategoria => kategoria.NazwaKategoria == nazwaKategoria);
                    Menu.danie.Add(new DanieVege(dishID, na, op, ce, k));

                }
                else if (type == "Rybne")
                {
                    Kategoria k = Kategoria.kategoria.FirstOrDefault(kategoria => kategoria.NazwaKategoria == nazwaKategoria);
                    Menu.danie.Add(new DanieRybne(dishID, na, op, ce, k));

                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wprowadzony zly typ");
                }

                Console.WriteLine("Chcesz kontynuowac 1-tak 2-nie");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    dishID++;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Pomyslnie dodano danie");


                }
                else if (choice == 2)
                {
                    loop = false;
                    Danie.StartOpcje();
                }
            }


        }

        public static void UsuwanieDan()
        {
            bool loop = true;
            while (loop)
            {
                Aplikacja.WyswietlWszystkieDania();
                Console.WriteLine("Wybierz id dania ktore chcesz usunac");
                int idD = Convert.ToInt32(Console.ReadLine());
                var matchingDish = Menu.danie.FirstOrDefault(d => d.Id == idD);

                if (matchingDish != null)
                {
                    Menu.UsunDanie(idD);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Pomyslnie usunieto danie");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nie ma dania z takim id");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ");
                Console.WriteLine("Czy chcesz jeszcze cos usunac 1-tak 2-nie");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Clear();
                }
                if (choice == 2)
                {
                    loop = false;
                    Danie.StartOpcje();
                }
            }
        }

        public static void TworzenieZamowien()

        {
            bool loop = true;
            
            int currentOrderId = 1;
            while (loop)
            {
                
                Console.WriteLine(" ");
                Aplikacja.WyswietlWszystkieDania();


                bool loop2 = true;
                var zamowienie1 = new Zamowienie(currentOrderId);
                zamowienie1.DataZamowienia = DateTime.Now;
                while (loop2)
                {
                    Console.WriteLine("Podaj id dania | 0 - dla wyjscia");
                    int idD = Convert.ToInt32(Console.ReadLine());

                    if (idD == 0)
                        loop2 = false;
                    else
                        zamowienie1.DodajDanie(idD);
                        
                        

                }
                Console.WriteLine("Pomyslnie stworzono zamowienie");
                Console.WriteLine("Chcesz stworzyc kolejne zamowienie 1-tak 2-nie");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    
                    Aplikacja.DodajZamowienie(zamowienie1);
                    currentOrderId++;
                    Console.Clear();
                    

                }
                else if  (choice == 2)
                {
                    Aplikacja.DodajZamowienie(zamowienie1);
                    loop = false;
                    Zamowienie.StartOpcje();
                    
                }
            }

        }

        public static void UsuwanieZamowien()
        {
            bool loop = true;
            while (loop)
            { 
            Console.Clear();
            Aplikacja.WyswietlZamowienia();
            Console.WriteLine(" ");
            bool loop2 = true;
            while (loop2) 
            {
                Console.WriteLine("Podaj id zamowienia ktore chcesz usunac 0 - dla wyjscia");
                int idZam = Convert.ToInt32(Console.ReadLine());
                if (idZam == 0)
                    loop2 = false;
                    
                else
                    Aplikacja.UsunZamowienie(idZam);
                    Console.Clear();
                    Console.WriteLine("Pomyslnie usunieto danie");
            }
                loop = false;
                Zamowienie.StartOpcje();

            }

        }

    }


}



