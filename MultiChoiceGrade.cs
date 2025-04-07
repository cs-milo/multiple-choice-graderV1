// ---------------------------------------------
// MultiChoiceGrade.cs
// Author: cs-milo
// Description: Version One Multiple Choice Grader
// Implements ITestPaper and IStudent interfaces
// for a basic test-taking and grading system.
// ---------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace MultipleChoiceGrader
{
    // Interface for a test paper
    public interface ITestPaper
    {
        string Subject { get; }
        string[] MarkScheme { get; }
        string PassMark { get; }
    }

    // Interface for a student
    public interface IStudent
    {
        string[] TestsTaken { get; }
        void TakeTest(ITestPaper paper, string[] answers);
    }

    // Concrete implementation of ITestPaper
    public class TestPaper : ITestPaper
    {
        public string Subject { get; }
        public string[] MarkScheme { get; }
        public string PassMark { get; }

        public TestPaper(string subject, string[] markScheme, string passMark)
        {
            Subject = subject;
            MarkScheme = markScheme;
            PassMark = passMark;
        }
    }

    // Concrete implementation of IStudent
    public class Student : IStudent
    {
        private List<string> _testsTaken = new List<string>();

        // Returns all tests taken or "No tests taken"
        public string[] TestsTaken
        {
            get
            {
                if (_testsTaken.Count == 0)
                    return new string[] { "No tests taken" };
                return _testsTaken.OrderBy(x => x).ToArray();
            }
        }

        // Takes a test and adds the result to tests taken
        public void TakeTest(ITestPaper paper, string[] answers)
        {
            int correct = 0;
            for (int i = 0; i < paper.MarkScheme.Length; i++)
            {
                if (i < answers.Length && paper.MarkScheme[i] == answers[i])
                {
                    correct++;
                }
            }

            double score = (double)correct / paper.MarkScheme.Length * 100;
            int roundedScore = (int)Math.Round(score);
            int passThreshold = int.Parse(paper.PassMark.TrimEnd('%'));

            string result = $"{paper.Subject}: {(roundedScore >= passThreshold ? "Passed" : "Failed")}! ({roundedScore}%)";
            _testsTaken.Add(result);
        }
    }

    // Optional test harness to demonstrate usage
    class Program
    {
        static void Main(string[] args)
        {
            var paper1 = new TestPaper("Maths", new string[] { "1A", "2C", "3D", "4A", "5A" }, "60%");
            var student1 = new Student();

            Console.WriteLine(string.Join(", ", student1.TestsTaken));  // Output: No tests taken

            student1.TakeTest(paper1, new string[] { "1A", "2D", "3D", "4A", "5A" });
            Console.WriteLine(string.Join(", ", student1.TestsTaken));  // Output: Maths: Passed! (80%)
        }
    }
}
