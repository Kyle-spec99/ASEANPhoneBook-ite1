
using System;
using System.Collections.Generic;

public class Phonebook
{
    // Stores all student objects
    private List<Student> students = new List<Student>();

    // Adds a student to the phonebook
    public void AddStudent(Student student)
    {
        students.Add(student);
        Console.WriteLine("Student successfully added!");
    }

    // Finds a student using their student number
    public Student? FindStudent(string studentNumber)
    {
        foreach (Student student in students)
        {
            if (student.StudentNumber == studentNumber)
            {
                return student;
            }
        }

        return null;
    }

    // Displays all students
    public void DisplayAllStudents()
    {
        foreach (Student student in students)
        {
            student.DisplayInfo();
        }
    }


public List<Student> SearchByCountries(
    List<int> countryCodes, bool allCountries)
{
    // Create a list for the search results
    List<Student> results = new List<Student>();

    // Check every student in the phonebook
    foreach (Student student in students)
    {
        if (allCountries || countryCodes.Contains(student.CountryCode))
        {
            results.Add(student);
        }
    }

    // Arrange students alphabetically by surname
    results.Sort((a, b) =>
        string.Compare(
            a.Surname,
            b.Surname,
            StringComparison.OrdinalIgnoreCase
        )
    );

    return results;
}

}
