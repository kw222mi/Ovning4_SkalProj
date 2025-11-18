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

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
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


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
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

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

