
# ASEAN Phonebook

## Description
A C# console application that stores and manages student contact information from five ASEAN countries.

## Supported Countries

| Country | Country Code |
|---|---|
| Malaysia | 60 |
| Indonesia | 62 |
| Philippines | 63 |
| Singapore | 65 |
| Thailand | 66 |

## Features
- Store student information
- Edit existing student information
- Search students by one or multiple countries
- Display all students
- Sort search results alphabetically by surname

## Technologies Used
- C#
- .NET
- Visual Studio Code
- Git

## How to Run

1. Install the .NET SDK.
2. Clone or download this repository.
3. Open the project folder in the terminal.
4. Run:

```bash
dotnet run
```

## Data Storage
Student information is stored temporarily in memory. Data is lost when the program exits.

## Project Structure
- `Program.cs` – Main menu and program operations.
- `Student.cs` – Student class and information.
- `Phonebook.cs` – Stores, finds, and searches student objects.
