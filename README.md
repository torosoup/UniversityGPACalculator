# University GPA Calculator

A simple C# console application for calculating university grade point averages based on courses, credits, and grades. Made for C# practice purposes.

## Features

* Add courses with name, credits, and grade
* Prevent duplicate course names
* Validate user input
* Calculate weighted GPA
* Support both letter grades (A–E) and Passed courses
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

## Future Improvements

* Remove or edit courses
* Multiple transcript support
* CSV export
* Automatic saving

## License

MIT License
