using System.Text.Json;
using UniversityGPACalculator.model;

namespace UniversityGPACalculator.data;

public class TranscriptRepository
{
    private readonly string filePath;

    public TranscriptRepository()
    {
        string folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "UniversityGPACalculator"
        );

        Directory.CreateDirectory(folder);

        filePath = Path.Combine(folder, "transcript.json");
    }
    
    /*  - FK7 Systemet skal tillate brukeren å lagre data fra en session til en fil. 
        - FK8 Systemet skal tillate brukeren å laste data fra transkript til session. */
    public void Save(List<Course> courses)
    {
        /* - FK9 Lagret data må inkludere: kursnavn, studiepoeng, karakterverdi */
        string json = JsonSerializer.Serialize(courses, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }

    public List<Course> Load()
    {
        if (!File.Exists(filePath))
            return new List<Course>();

            /* - FK10 Lasting av transcript skal bytte den nåværende kurslisten i minnet. */
        try
        {
            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Course>>(json)
                   ?? new List<Course>();
        }
        /* - FK11 Om fil ikke eksisterer, skal systemet ikke crashe, men gi tilbakemelding og returnere en tom liste. */
        catch
        {
            Console.WriteLine("Could not load transcript. Starting fresh.");
            return new List<Course>();
        }
    }
}