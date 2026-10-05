using System;
namespace Lab5.Models
{
    public class StudentGrade
    {
        public StudentGrade(string studentName, double grade)
        {
            StudentName = studentName ??
            throw new ArgumentNullException(nameof(studentName));
            Grade = grade;
        }
        public string StudentName { get; }
        public double Grade { get; }
        public override string ToString() => $"{StudentName} - {Grade:F2}";
    }
}