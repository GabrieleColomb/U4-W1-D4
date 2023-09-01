using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_W1_D4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("Scegli l’operazione da effettuare:");
                Console.WriteLine("1.: Login");
                Console.WriteLine("2.: Logout");
                Console.WriteLine("3.: Verifica ora e data di login");
                Console.WriteLine("4.: Lista degli accessi");
                Console.WriteLine("5.: Esci");
                Console.WriteLine("========================================");
                Console.Write("Scelta: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Utente.Login();
                            break;
                        case 2:
                            Utente.Logout();
                            break;
                        case 3:
                            Utente.VerificaLogin();
                            break;
                        case 4:
                            Utente.ListaAccessi();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Scelta non valida. Riprova.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Scelta non valida. Riprova.");
                }

            } while (true);
        }
    }
}