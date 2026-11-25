
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
                        StoreStudent(phonebook);
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


static void StoreStudent(Phonebook phonebook)
{
    string another = "Y";

    while (another.ToUpper() == "Y")
    {
        Console.WriteLine("\n===== ADD STUDENT =====");

        Console.Write("Enter student number: ");
        string studentNumber = Console.ReadLine() ?? "";

        Console.Write("Enter surname: ");
        string surname = Console.ReadLine() ?? "";

        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine() ?? "";

        Console.Write("Enter occupation: ");
        string occupation = Console.ReadLine() ?? "";

        string gender;

        do
        {
            Console.Write("Enter gender (M for male, F for female): ");
            gender = (Console.ReadLine() ?? "").ToUpper();

            if (gender != "M" && gender != "F")
            {
                Console.WriteLine("Invalid gender! Enter M or F.");
            }

        } while (gender != "M" && gender != "F");

        int countryCode;

        do
        {
            Console.Write("Enter country code: ");

            bool validNumber = int.TryParse(
                Console.ReadLine(), out countryCode);

            if (!validNumber ||
                (countryCode != 60 &&
                 countryCode != 62 &&
                 countryCode != 63 &&
                 countryCode != 65 &&
                 countryCode != 66))
            {
                Console.WriteLine("Invalid country code! Try again.");
                countryCode = 0;
            }

        } while (countryCode == 0);

        int areaCode;

        Console.Write("Enter area code: ");

        while (!int.TryParse(Console.ReadLine(), out areaCode))
        {
            Console.Write("Invalid area code. Enter again: ");
        }

        Console.Write("Enter number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        // Create a new Student object
        Student newStudent = new Student(
            studentNumber,
            surname,
            firstName,
            occupation,
            gender,
            countryCode,
            areaCode,
            phoneNumber
        );

        // Add the student to the phonebook
        phonebook.AddStudent(newStudent);

        Console.Write("\nDo you want to enter another entry [Y/N]? ");
        another = (Console.ReadLine() ?? "").ToUpper();

        while (another != "Y" && another != "N")
        {
            Console.Write("Please enter Y or N: ");
            another = (Console.ReadLine() ?? "").ToUpper();
        }
    }
}

}


