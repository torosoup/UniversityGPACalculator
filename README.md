# University GPA Calculator

A simple C# console application for calculating university GPA based on completed courses and grades. Made for C# practice purposes.

## Features

* Calculate GPA from multiple courses
* Support for letter grades
* Automatic grade point conversion
* Displays total credits and GPA
* Simple console-based user interface

## Project Structure

```text
UniversityGPACalculator/
│
├── data/
│   ├── GradeCalculator.cs
|
├── model/
│   ├── Course.cs
│   └── Grade.cs
│
├── Program.cs
├── UniversityGPACalculator.csproj
└── README.md
```

## Requirements

* .NET SDK
* Windows, Linux, or macOS

## Installation

Clone the repository:

```bash
git clone <repository-url>
cd UniversityGPACalculator
```

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

## Usage

1. Start the application.
2. Enter course information when prompted.
3. Enter grades and credit values.
4. The application calculates and displays the GPA.

Example:

```text
Course: IN1010
Credits: 10
Grade: A

Course: IN2000
Credits: 10
Grade: B

GPA: 4.50
```

## Grade Scale

| Grade | Points |
| ----- | ------ |
| A     | 5      |
| B     | 4      |
| C     | 3      |
| D     | 2      |
| E     | 1      |
| F     | 0      |

## Technologies

* C#
* .NET
* Object-Oriented Programming

## Future Improvements

* Save and load transcripts
* Export results to CSV
* GUI version using WPF or WinForms
* Unit tests

## License

This project is licensed under the MIT License.
