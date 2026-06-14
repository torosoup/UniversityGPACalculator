using UniversityGPACalculator.model;

public class GradeCalculator
{
    public double CalculateAverage(List<Course> courses)
    {
        int totalPoints = 0;
        int gradedCredits = 0;

        foreach (Course course in courses)
        {
            if (course.grade == Grade.Passed) {continue;}
            totalPoints += (int)course.grade * course.credits;
            gradedCredits += course.credits;
        }
        if (gradedCredits == 0) {return 0;}

        return (double)totalPoints / gradedCredits;
    }

    public (int TotalCredits, int PassedCredits) CalculateCredits(List<Course> courses)
    {
        int totalCredits = 0;
        int passedCredits = 0;

        foreach (Course course in courses) {

            totalCredits += course.credits;

            if (course.grade == Grade.Passed) 
            {
                passedCredits += course.credits;
            }

            }

        return (totalCredits, passedCredits);
    }

    public string AverageToLetter(double average)
    {
    return average switch
        {
        >= 4.5 => "A",
        >= 3.5 => "B",
        >= 2.5 => "C",
        >= 1.5 => "D",
        > 0 => "E",
        _ => "-"
        };
    }
}