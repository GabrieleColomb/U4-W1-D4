using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4_W1_D4
{
    internal class Utente
    {
    private static string username;
        private static string password;
        private static DateTime ultimoLogin;
        private static DateTime ultimoLogout;
        private static List<Tuple<string, DateTime, DateTime>> accessi = new List<Tuple<string, DateTime, DateTime>>();

        public static void Login()
        {
            Console.Write("Username: ");
            string inputUsername = Console.ReadLine();

            Console.Write("Password: ");
            string inputPassword = Console.ReadLine();

            Console.Write("Conferma password: ");
            string confirmPassword = Console.ReadLine();

            if (inputUsername != "" && inputPassword == confirmPassword)
            {
                username = inputUsername;
                password = inputPassword;
                ultimoLogin = DateTime.Now;
                accessi.Add(new Tuple<string, DateTime, DateTime>(username, ultimoLogin, DateTime.MinValue));

                Console.WriteLine("Login effettuato con successo.");
            }
            else
            {
                Console.WriteLine("Errore nell'autenticazione.");
            }
        }

        public static void Logout()
        {
            if (!string.IsNullOrEmpty(username))
            {
                ultimoLogout = DateTime.Now;
                var lastAccess = accessi.FindLast(a => a.Item1 == username);
                accessi[accessi.IndexOf(lastAccess)] = Tuple.Create(lastAccess.Item1, lastAccess.Item2, ultimoLogout);

                username = null;
                password = null;

                Console.WriteLine("Logout effettuato.");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato.");
            }
        }

        public static void VerificaLogin()
        {
            if (!string.IsNullOrEmpty(username))
            {
                Console.WriteLine($"Ultimo login: {ultimoLogin}");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato.");
            }
        }

        public static void ListaAccessi()
        {
            if (accessi.Count > 0)
            {
                Console.WriteLine("Storico accessi:");
                foreach (var accesso in accessi)
                {
                    Console.WriteLine($"Utente: {accesso.Item1}, Login: {accesso.Item2}, Logout: {accesso.Item3}");
                }
            }
            else
            {
                Console.WriteLine("Nessun accesso registrato.");
            }
        }
    }
}