using System;
using System.Collections.Generic;
namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            //Färger
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            //-------------------------------------------

            Console.WriteLine("Hur många koder vill du skriva in?");
            int nrOfCodes = ReadInt();

            Dictionary<char,char> codes = new Dictionary<char,char>();
            string userInput;
            //Input
            Console.WriteLine("Skriv koderna som \"a b\".");
            for (int i = 0; i < nrOfCodes; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Kod nr. {i + 1}:");
                    userInput = Console.ReadLine();

                    try
                    {
                        if (userInput[1] != ' ')
                        {
                            Console.WriteLine("Du skrev fel. Försök igen.");
                            continue;
                        }
                        codes[userInput[0]] = userInput[2];
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Du skrev fel. Försök igen.");
                        continue;
                    }
                }
            }

            Console.WriteLine("Skriv in ditt hemliga meddelande:");
            userInput = Console.ReadLine();
            //Lägger in varje bokstav från användarens input som en index i en array
            char[] decodedMessage = new char[userInput.Length];
            for (int i = 0; i < userInput.Length; i++)
            {
                decodedMessage[i] = userInput[i];
            }

            //Löser koden
            //Loopar efter hur många koder som finns, ifall vissa koder påverkar andra, t.ex. a>b och b>e
            for (int a = 0; a < nrOfCodes; a++) 
            {
                //Går igenom varje index i arrayen med det som ska lösas
                for (int i = 0; i < decodedMessage.Length; i++)
                {
                    //jämför varje index i "decodedMessage" med varje nyckel i dictionaryn "codes".
                    //Passar de ska en bokstav bytas ut dictionaryns värde
                    foreach (var code in codes)
                    {
                        if (code.Key == decodedMessage[i])
                        {
                            decodedMessage[i] = code.Value;
                            break;
                        }
                    }
                }
            }

            //Utskrift
            Console.WriteLine("Här är ditt avkodade meddelande:");
            foreach (char letter in decodedMessage)
            {
                Console.Write(letter);
            }
        }

        static int ReadInt()
        {
            int integer;
            while (int.TryParse(Console.ReadLine(), out integer) == false)
            {
                Console.WriteLine("Du skrev inte in ett heltal. Försök igen.");
            }
            return integer;
        }
    }
}
/*I denna uppgift ska du skapa ett program som kan avkoda hemliga meddelanden
med hjälp av koder. Först ska användaren få skriva in hur många koder som hen vill
ange. Därefter ska man ange alla sina koder på formen &quot;X Y&quot;, vilket innebär att alla
gånger X finns med i det hemliga meddelandet så ska det bytas ut mot Y. Slutligen
ska användaren skriva in ett hemligt meddelande som ska avkodas med hjälp av de
koder som har matats in.
Ett exempel på en körning av programmet skulle kunna se ut så här:
Hur många koder vill du skriva in?
5
c b
d a
b z
e i
f c
Skriv in ditt hemliga meddelande
pebfd
Här är ditt avkodade meddelande:
pizza
Vi går igenom det hemliga meddelandet pedcd tecken för tecken och ser hur det har
avkodats.
 Det finns ingen kod som innehåller p, så det behöver inte ändras.
 Enligt en av koderna ska alla e bytas till i, så det andra tecknet blir i.
 Alla b bytas till z, så det tredje tecknet blir z.
 Alla f ska bytas till c. Eftersom det finns en regel för c så måste detta
sedan bytas till b. Eftersom det också finns regel för b måste detta bytas
till z. Detta leder slutligen till att det fjärde tecknet blir ett z.
 Alla d ska bytas till a, så det femte tecknet blir ett a.*/