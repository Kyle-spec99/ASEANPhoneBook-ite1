
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
                        EditStudent(phonebook);
                        break;

                    case 3:
                        SearchStudents(phonebook);
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


static void EditStudent(Phonebook phonebook)
{
    Console.WriteLine("\n===== EDIT STUDENT =====");

    Console.Write("Enter student number: ");
    string studentNumber = Console.ReadLine() ?? "";

    // Find the student
    Student? student = phonebook.FindStudent(studentNumber);

    // Check if student exists
    if (student == null)
    {
        Console.WriteLine("Student not found!");
        return;
    }

    // Keep showing the edit menu
    int choice = 0;

    while (choice != 8)
    {
        Console.WriteLine("\nHere is the existing information:");
        Console.WriteLine("Student Number: " + student.StudentNumber);
        student.DisplayInfo();

        Console.WriteLine("\nWhich information do you wish to change?");
        Console.WriteLine("[1] Student number");
        Console.WriteLine("[2] Surname");
        Console.WriteLine("[3] Gender");
        Console.WriteLine("[4] Occupation");
        Console.WriteLine("[5] Country code");
        Console.WriteLine("[6] Area code");
        Console.WriteLine("[7] Phone number");
        Console.WriteLine("[8] None - Go back to main menu");

        Console.Write("Enter choice: ");

        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid choice!");
            choice = 0;
            continue;
        }

        switch (choice)
        {
            case 1:
                Console.Write("Enter new student number: ");
                student.StudentNumber = Console.ReadLine() ?? "";
                break;

            case 2:
                Console.Write("Enter new surname: ");
                student.Surname = Console.ReadLine() ?? "";
                break;

            case 3:
                string gender;

                do
                {
                    Console.Write("Enter new gender (M/F): ");
                    gender = (Console.ReadLine() ?? "").ToUpper();

                    if (gender != "M" && gender != "F")
                    {
                        Console.WriteLine("Invalid gender!");
                    }

                } while (gender != "M" && gender != "F");

                student.Gender = gender;
                break;

            case 4:
                Console.Write("Enter new occupation: ");
                student.Occupation = Console.ReadLine() ?? "";
                break;

            case 5:
                int newCountryCode;

                while (true)
                {
                    Console.Write("Enter new country code: ");

                    if (int.TryParse(Console.ReadLine(), out newCountryCode) &&
                        (newCountryCode == 60 ||
                         newCountryCode == 62 ||
                         newCountryCode == 63 ||
                         newCountryCode == 65 ||
                         newCountryCode == 66))
                    {
                        break;
                    }

                    Console.WriteLine("Invalid country code! Try again.");
                }

                student.CountryCode = newCountryCode;
                break;

            case 6:
                int newAreaCode;

                Console.Write("Enter new area code: ");

                while (!int.TryParse(Console.ReadLine(), out newAreaCode))
                {
                    Console.Write("Invalid area code. Enter again: ");
                }

                student.AreaCode = newAreaCode;
                break;

            case 7:
                Console.Write("Enter new phone number: ");
                student.PhoneNumber = Console.ReadLine() ?? "";
                break;

            case 8:
                Console.WriteLine("Returning to main menu...");
                break;

            default:
                Console.WriteLine("Invalid choice! Please try again.");
                break;
        }

        if (choice >= 1 && choice <= 7)
        {
            Console.WriteLine("\nInformation successfully updated!");
        }
    }
}


static void SearchStudents(Phonebook phonebook)
{
    List<int> selectedCountries = new List<int>();
    List<string> countryNames = new List<string>();

    bool allCountries = false;
    int choice = -1;

    Console.WriteLine("\n===== SEARCH BY COUNTRY =====");
    Console.WriteLine("From which country:");
    Console.WriteLine("[1] Philippines");
    Console.WriteLine("[2] Thailand");
    Console.WriteLine("[3] Singapore");
    Console.WriteLine("[4] Indonesia");
    Console.WriteLine("[5] Malaysia");
    Console.WriteLine("[6] ALL");
    Console.WriteLine("[0] No More");

    while (choice != 0 && !allCountries)
    {
        Console.Write("Enter choice: ");

        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid choice!");
            choice = -1;
            continue;
        }

        switch (choice)
        {
            case 1:
                selectedCountries.Add(63);
                countryNames.Add("Philippines");
                break;

            case 2:
                selectedCountries.Add(66);
                countryNames.Add("Thailand");
                break;

            case 3:
                selectedCountries.Add(65);
                countryNames.Add("Singapore");
                break;

            case 4:
                selectedCountries.Add(62);
                countryNames.Add("Indonesia");
                break;

            case 5:
                selectedCountries.Add(60);
                countryNames.Add("Malaysia");
                break;

            case 6:
                allCountries = true;
                countryNames.Clear();
                countryNames.Add("ALL COUNTRIES");
                break;

            case 0:
                break;

            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    if (selectedCountries.Count == 0 && !allCountries)
    {
        Console.WriteLine("No countries selected.");
        return;
    }

    // Get the matching students
    List<Student> results =
        phonebook.SearchByCountries(selectedCountries, allCountries);

    Console.WriteLine("\nHere are the students from " +
        string.Join(" and ", countryNames) + ":");

    if (results.Count == 0)
    {
        Console.WriteLine("No students found.");
    }
    else
    {
        foreach (Student student in results)
        {
            Console.WriteLine(
                $"{student.Surname}, {student.FirstName}, " +
                $"with student number {student.StudentNumber}, " +
                $"is a {student.Occupation}. " +
                $"His/Her phone number is " +
                $"{student.CountryCode}-{student.AreaCode}-{student.PhoneNumber}"
            );
        }
    }
}



}


