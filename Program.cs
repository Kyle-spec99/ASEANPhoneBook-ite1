
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the phonebook object
        Phonebook phonebook = new Phonebook();

        int choice = 0;

        // Keep showing the menu until the user exits
        while (choice != 4)
        {
            Console.WriteLine("\n===== ASEAN PHONEBOOK =====");
            Console.WriteLine("[1] Store to ASEAN phonebook");
            Console.WriteLine("[2] Edit entry in ASEAN phonebook");
            Console.WriteLine("[3] Search ASEAN phonebook by country");
            Console.WriteLine("[4] Exit");

            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Store feature is coming next!");
                        break;

                    case 2:
                        Console.WriteLine("Edit feature is not available yet.");
                        break;

                    case 3:
                        Console.WriteLine("Search feature is not available yet.");
                        break;

                    case 4:
                        Console.WriteLine("Thank you for using ASEAN Phonebook!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
                choice = 0;
            }
        }
    }
}
