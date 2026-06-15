# University GPA Calculator

A simple C# console application for calculating university grade point averages based on courses, credits, and grades. Made for C# practice purposes.

## Features

* Add courses with name, credits, and grade to list
* Show overview of list with added courses with name, credits, and grade
* Calculate weighted GPA
* Save and load transcripts in %AppData% using JSON

## Technologies

* C#
* .NET
* JSON serialization (`System.Text.Json`)

## How to Run

```bash
dotnet run
```

## Example

```text
=== University Grade Calculator ===

1. Add course
2. Show courses
3. Calculate GPA
4. Save transcript (JSON)
5. Load transcript (JSON)
6. Exit
```

## Project Structure

```text
UniversityGPACalculator/
│
├── Program.cs
├── model/
│   ├── Course.cs
│   └── Grade.cs
│
├── data/
│   ├── GradeCalculator.cs
│   └── TranscriptRepository.cs
│
└── README.md
```

## License

MIT License
