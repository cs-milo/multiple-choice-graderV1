# Multiple Choice Grader - Version One

## Author
cs-milo

## Overview
This is Version One of the **Multiple Choice Grader** program, a C# console application designed to simulate the test-taking and grading process for students. This version focuses on implementing the core object-oriented structure using interfaces and classes.

> 📌 Note: This version **does not include** user input, menus, or file storage. Those features are part of the final version.

---

## Features

- `ITestPaper` Interface: Defines a test paper with a subject, mark scheme, and pass mark.
- `IStudent` Interface: Defines a student who can take tests and keep track of results.
- `TestPaper` Class: Implements the `ITestPaper` interface.
- `Student` Class: Implements the `IStudent` interface and handles test grading logic.
- Grading logic includes:
  - Percentage calculation
  - Rounding to the nearest whole number
  - Sorting test results alphabetically by subject
  - Marking as "Passed" or "Failed" based on the pass mark

---

## How to Run

### Prerequisites
- .NET 6.0 SDK or later
- Visual Studio Code or Command Prompt/Terminal

### Steps

1. Open terminal or command prompt.
2. Navigate to the project directory:
   ```bash
   cd path/to/MultiChoiceGrade
   ```
3. Run the program:
   ```bash
   dotnet run
   ```

---

## Example Output

```
No tests taken
Maths: Passed! (80%)
```

---

## Files

- `MultiChoiceGrade.cs`: Main source file containing interfaces, classes, and test code.
- `MultiChoiceGrade.csproj`: Project file required for .NET.
- `README.md`: This documentation file.

---

## License
This project is for educational use only.
