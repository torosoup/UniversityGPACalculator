using System;
using System.Collections.Generic;
using UniversityGPACalculator.model;

public class Program
{
    static void Main(string[] args)
    {
        var courses = new List<Course>();
        var calculator = new GradeCalculator();

        while (true)
        {
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
        Console.Write("Course name: ");
        string name = Console.ReadLine() ?? ""; // refaktorer senere

        int credits = ReadCredits(); // int.Parse(Console.ReadLine()); // nf-req 3
        Grade grade = ReadGrade();

        // Grade grade = ParseGrade(gradeInput);

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

        Console.WriteLine("\n--- Result ---");
        Console.WriteLine($"Average: {average:F2} ({calculator.AverageToLetter(average)})");
        Console.WriteLine($"Total credits in calculation: {totalCredits - passedCredits}");
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
}
