using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Lab5.Models;
namespace Lab5.Services
{
    public sealed class GradeBook
    {
        private readonly List<StudentGrade> _entries = new List<StudentGrade>();
        public IReadOnlyList<StudentGrade> Entries => _entries;
        public int Count => _entries.Count;
        public void Add(string studentName, string gradeText)
        {
            var normalizedName = NormalizeStudentName(studentName);
            var grade = ParseGrade(gradeText);
            _entries.Add(new StudentGrade(normalizedName, grade));
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _entries.Count)
            {
                throw new ArgumentOutOfRangeException(
                nameof(index),
                "Indicele selectat nu este valid.");
            }
            _entries.RemoveAt(index);
        }

        public void SortItems()
        {
            EnsureHasEntries();
            List<StudentGrade> sortedList = _entries.OrderBy(s => s.StudentName).ToList();
            _entries.Clear();
            _entries.AddRange(sortedList);
        }
        public double GetAverage()
        {
            EnsureHasEntries();
            return _entries.Average(entry => entry.Grade);
        }
        public StudentGrade GetMaxGradeEntry()
        {
            EnsureHasEntries();
            return _entries.OrderByDescending(entry => entry.Grade).First();
        }
        public StudentGrade GetMinGradeEntry()
        {
            EnsureHasEntries();
            return _entries.OrderBy(entry => entry.Grade).First();
        }
        public int SearchByName(string searchTerm)
        {
            int index = _entries.FindIndex(entry => entry.StudentName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
            {
                throw new ArgumentException(
                "Nu am putut gasi nimic.");
            }
            else return index;
        }
        public IReadOnlyList<StudentGrade> GetStudentsBelowAverage()
        {
            var average = GetAverage();
            return _entries
            .Where(entry => entry.Grade < average)
            .OrderBy(entry => entry.StudentName)
            .ToList();
        }
        public IReadOnlyList<StudentGrade> GetStudentsAboveAverage()
        {
            var average = GetAverage();
            return _entries
            .Where(entry => entry.Grade >= average)
            .OrderBy(entry => entry.StudentName)
            .ToList();
        }
        private static string NormalizeStudentName(string studentName)
        {
            if (string.IsNullOrWhiteSpace(studentName))
            {
                throw new ArgumentException(
                "Numele studentului este obligatoriu.");
            }
            var normalized = studentName.Trim();
            if (normalized.Any(char.IsDigit))
            {
                throw new ArgumentException(
                "Numele studentului nu poate conține cifre.");
            }
            return normalized;
        }
        private static double ParseGrade(string gradeText)
        {
            if (string.IsNullOrWhiteSpace(gradeText))
            {
                throw new ArgumentException("Nota studentului este obligatorie.");
            }
            var normalized = gradeText.Trim().Replace(',', '.');
            if (!double.TryParse(normalized, NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture, out var grade))
            {
                throw new ArgumentException(
                "Nota trebuie să fie un număr valid.");
            }
            if (grade < 1 || grade > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(gradeText),
                "Nota trebuie să fie în intervalul [1, 10].");
            }
            return grade;
        }
        private void EnsureHasEntries()
        {
            if (_entries.Count == 0)
            {
                throw new InvalidOperationException(
                "Nu există note înregistrate.");
            }
        }
    }
}