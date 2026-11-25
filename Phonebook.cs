
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
}
