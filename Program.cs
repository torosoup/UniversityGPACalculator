using System;
using System.Linq;
using System.Collections.Generic;
using UniversityGPACalculator.model;
using System.Net;

public class Program
{
    static void Main(string[] args)
    {
        var courses = new List<Course>();
        var calculator = new GradeCalculator();

        while (true)
        {
            /*
            - FK1 Registrering av emner: Systemet skal la brukeren registrere ett eller flere emner med: Emnekode eller emnenavn, antall studiepoeng, Karakter (A-E) eller bestått.
            - FK5 Registrering av flere emner: Brukeren skal kunne legge til flere emner før snittet beregnes
            - FK6 Avslutning av registrering: Brukeren skal kunne velge når registreringen av emner er ferdig og beregningen skal utføres.
            */

            Console.WriteLine("\n=== University Grade Calculator ===");
            Console.WriteLine("1. Add course");
            Console.WriteLine("2. Show courses");
            Console.WriteLine("3. Calculate GPA");
            Console.WriteLine("4. Exit");
            Console.Write("Choose: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddCourse(courses);
                    break;
                case "2":
                    ShowCourses(courses);
                    break;
                case "3":
                    Calculate(courses, calculator);
                    break;
                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
                
            }
        }
    }

    static void AddCourse(List<Course> courses)
    {

        /* 
        - FK4 Validering av inndata: Systemet skal kontrollere at: Studiepoeng er større enn 0, 
        Karakter kun er A-E, Obligatoriske felt ikke er tomme. Emner skal ha unike navn.
        */

        string name = ReadName(courses);
        int credits = ReadCredits();
        Grade grade = ReadGrade();

        courses.Add(new Course
        {
            name = name,
            credits = credits,
            grade = grade
        });

        Console.WriteLine("Course added!");
    }

    static void ShowCourses(List<Course> courses)
    {
        Console.WriteLine("\n--- Courses ---");

        foreach (var course in courses)
        {
            Console.WriteLine($"{course.name} - {course.credits}SP - {course.grade}");
        }
    }

    static void Calculate(List<Course> courses, GradeCalculator calculator)
    {
        var average = calculator.CalculateAverage(courses);
        var (totalCredits, passedCredits) = calculator.CalculateCredits(courses);

        /* FK3 Visning av resultat: Systemet skal vise: Totalt antall studiepoeng, Beregnet snitt med to desimaler, Tilsvarende bokstavsnitt (A-E). */

        Console.WriteLine("\n--- Result ---");
        Console.WriteLine($"Average: {average:F2} ({calculator.AverageToLetter(average)})");
        Console.WriteLine($"Total credits in calculation: {totalCredits - passedCredits}"); // Karakterer av karakterverdi "bestått" skal ikke inkluderes i beregningen av karaktersnitt. 

    }
    static int ReadCredits()
    {
    while (true)
        {
        Console.Write("Credits: ");

        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out int credits) && credits > 0)
        {
            return credits;
        }

        Console.WriteLine("Invalid input. Credits must be a positive whole number.");
        }
    }

    static Grade ReadGrade()
    {
    while (true)
        {
        Console.Write("Grade (A/B/C/D/E/Passed): ");
        string input = (Console.ReadLine() ?? "").Trim().ToUpper();
        
        switch (input)
            {
            case "A":
                return Grade.A;

            case "B":
                return Grade.B;

            case "C":
                return Grade.C;

            case "D":
                return Grade.D;

            case "E":
                return Grade.E;

            case "PASSED":
                return Grade.Passed;

            default:
                Console.WriteLine("Invalid grade. Please enter A, B, C, D, E or Passed.");
                break;
        }
        }
    }

    static string ReadName(List<Course> courses)
    {
        while (true) 
        {
            Console.Write("Course name: ");
            string? name = Console.ReadLine();

            /* Obligatoriske felt ikke er tomme. Emner skal ha unike navn. */
            
            if (string.IsNullOrWhiteSpace(name))
            
            {
                Console.WriteLine("Name cannot be empty");
                continue;
            }
            
            if (courses.Any(c => c.name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("A course with that name already exists.");
                continue;
            }

            return name;
        }
    }
}
