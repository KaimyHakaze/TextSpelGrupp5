using System;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Game game = new Game();
                game.Run();

                while(true)
                {
                    System.Console.WriteLine("Skriv 's' för att spela igen eller 'a' för att avsluta");
                    string input = Console.ReadLine();
                    input = input.Trim(); 
                    input = input.ToLower(); 
                    if (input == "s")
                    {
                        break; 
                    }
                    else if (input == "a")
                    {
                        Environment.Exit(1); 
                    }
                }
            }
        }
    }
}
