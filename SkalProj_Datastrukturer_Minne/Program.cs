using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /*
   När en List<T> blir full ökar den automatiskt sin kapacitet.
   Detta görs genom att den interna arrayen *dubblas* i storlek, vilket ger plats för fler element
   utan att programmeraren behöver ange storleken i förväg.

   När man tar bort element ur listan minskar däremot inte kapaciteten. Den interna arrayen behåller
   sin storlek även om listan blir nästan tom. Detta är avsiktligt, eftersom en dynamiskt krympande 
   kapacitet skulle påverka prestandan negativt.

   Den stora fördelen med List<T> är just flexibiliteten: den kan växa när det behövs, och passar bra
   när man inte vet hur många element som kommer att lagras.

   En array har alltid en fast längd och kan inte utökas. Om man däremot vet exakt hur många element 
   som behövs — till exempel maximalt 26 bokstäver — är en array ofta mer effektiv. En array använder 
   oftast mindre minne och kan ge något snabbare åtkomst, eftersom ingen dynamisk omallokering sker.
*/

        static void ExamineList()
        {
      
            List<string> theList = new List<string>();

                while (true)
                {
                    Console.WriteLine("\nSkriv +namn för att lägga till, -namn för att ta bort, eller 0 för att gå tillbaka.");
                    Console.Write("Input: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Du måste skriva något!");
                        continue;
                    }

                    // Avsluta om användaren skriver 0
                    if (input == "0")
                        break;

                    char command = input[0];               // + eller -
                    string value = input.Substring(1);      // resten av texten

                    switch (command)
                    {
                        case '+':
                            theList.Add(value);
                            Console.WriteLine($"{value} lades till i listan.");
                            break;

                        case '-':
                            if (theList.Remove(value))
                                Console.WriteLine($"{value} togs bort ur listan.");
                            else
                                Console.WriteLine($"{value} fanns inte i listan.");
                            break;

                        default:
                            Console.WriteLine("Använd + eller - följt av ett namn.");
                            break;
                    }

                    // Visa listans nuvarande Count och Capacity
                    Console.WriteLine($"Count: {theList.Count}");
                    Console.WriteLine($"Capacity: {theList.Capacity}");

                    // Skriv även ut listans innehåll
                    Console.WriteLine("Innehåll: " + string.Join(", ", theList));
                }
            


        }


        /*
     Demonstrerar hur en Queue fungerar (FIFO – First In, First Out).
     E <namn> lägger till en person sist i kön (Enqueue).
     D tar bort personen som står först (Dequeue).

     En kö används när ordningen ska bevaras och den som kom först
     också ska betjänas först – t.ex. en ICA-kö.
 */

        static void ExamineQueue()
        {
            

                Queue<string> queue = new Queue<string>();

                while (true)
                {
                    Console.WriteLine("\nAnvänd E <namn> för att enqueue (ställa sig i kön),");
                    Console.WriteLine("D för att dequeue (nästa kund lämnar kön), eller 0 för att gå tillbaka.");
                    Console.Write("Input: ");

                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Du måste skriva något!");
                        continue;
                    }

                    // Avsluta och gå tillbaka till huvudmenyn
                    if (input == "0")
                        break;

                    char command = input[0];                   // E eller D
                    string value = input.Length > 1 ? input.Substring(1).Trim() : "";

                    switch (command)
                    {
                        case 'E':   // Enqueue (lägg till i kön)
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                Console.WriteLine("Du måste ange ett namn efter E.");
                                break;
                            }

                            queue.Enqueue(value);
                            Console.WriteLine($"{value} ställde sig i kön.");
                            break;

                        case 'D':   // Dequeue (ta bort första i kön)
                            if (queue.Count > 0)
                            {
                                string removed = queue.Dequeue();
                                Console.WriteLine($"{removed} lämnade kön.");
                            }
                            else
                            {
                                Console.WriteLine("Kön är tom — ingen kan lämna.");
                            }
                            break;

                        default:
                            Console.WriteLine("Använd E <namn> eller D.");
                            break;
                    }

                    // Visa nuvarande innehåll i kön
                    Console.WriteLine("Nuvarande kö: " +
                        (queue.Count > 0 ? string.Join(", ", queue) : "(tom)"));
                }
            

        }

        /*
      Demonstrerar hur en Stack fungerar (LIFO – Last In, First Out).
      P <värde> lägger till ett element överst (Push).
      O tar bort det senast tillagda elementet (Pop).

      En stack passar när det som lades in sist ska hanteras först,
      som tex ångra-funktioner eller parentesmatchning – men inte köer.
  */

        static void ExamineStack()
        {
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("\nAnvänd P <värde> för Push (lägga överst),");
                Console.WriteLine("O för Pop (ta bort översta), eller 0 för att gå tillbaka.");
                Console.Write("Input: ");

                string input = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Du måste skriva något!");
                    continue;
                }

                // Avsluta
                if (input == "0")
                    break;

                char command = input[0];
                string value = input.Length > 1 ? input.Substring(1).Trim() : "";

                switch (command)
                {
                    case 'P':  // Push
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            Console.WriteLine("Du måste ange ett värde efter P.");
                            break;
                        }

                        stack.Push(value);
                        Console.WriteLine($"{value} lades överst i stacken.");
                        break;

                    case 'O':  // Pop
                        if (stack.Count > 0)
                        {
                            string removed = stack.Pop();
                            Console.WriteLine($"{removed} togs bort från toppen av stacken.");
                        }
                        else
                        {
                            Console.WriteLine("Stacken är tom — inget att ta bort.");
                        }
                        break;

                    default:
                        Console.WriteLine("Använd P <värde> eller O.");
                        break;
                }

                // Visa stackens innehåll
                Console.WriteLine("Nuvarande stack (överst först): " +
                    (stack.Count > 0 ? string.Join(", ", stack) : "(tom)"));
            }
        }

        /*
    Kontrollerar om en sträng har korrekt placerade parenteser.

    En stack används eftersom den följer LIFO (Last In, First Out), vilket passar
    perfekt för parenteser: den senaste öppnade parentesen måste alltid stängas först.

    Algoritm:
    - Lägg öppnande parenteser på stacken.
    - Vid stängande parentes:
         * Om stacken är tom → fel.
         * Poppa och kontrollera att parenteserna matchar.
    - Efteråt:
         * Tom stack → korrekt.
         * Ej tom stack → några parenteser saknar stängning.

    Exempel korrekt: (), {[]}, [({})]
    Exempel fel: (], {[)}, (()
*/

        static void CheckParanthesis()
        {
            
                Console.WriteLine("\nSkriv en sträng med parenteser att kontrollera:");
                string input = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Du måste skriva något!");
                    return;
                }

                Stack<char> stack = new Stack<char>();

                foreach (char c in input)
                {
                    // Om öppnande parentes → lägg på stacken
                    if (c == '(' || c == '{' || c == '[')
                    {
                        stack.Push(c);
                    }
                    // Om stängande parentes → kolla om den matchar senaste öppnade
                    else if (c == ')' || c == '}' || c == ']')
                    {
                        if (stack.Count == 0)
                        {
                            Console.WriteLine("Fel: Det finns en stängande parentes utan motsvarighet.");
                            return;
                        }

                        char last = stack.Pop();

                        if (!IsMatchingPair(last, c))
                        {
                            Console.WriteLine($"Fel: {last} matchar inte {c}");
                            return;
                        }
                    }
                }

                // Om stacken inte är tom → det finns öppningar utan stängningar
                if (stack.Count == 0)
                    Console.WriteLine("Korrekt: Alla parenteser är välformade!");
                else
                    Console.WriteLine("Fel: Några parenteser stängdes aldrig.");
            }

            static bool IsMatchingPair(char open, char close)
            {
                return (open == '(' && close == ')') ||
                       (open == '{' && close == '}') ||
                       (open == '[' && close == ']');
            }


        

    }
}

