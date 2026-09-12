using System.ComponentModel;

namespace ConsoleApp3
{
    public static class ExtensionMethods
    {
        public static bool IsPassing(this int score)
        {
            return score >= 60;
        }
    }
    public class Student
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }

    public class Enrrollment
    {
        public required int Id { get; set; }
        public required int StudentId { get; set; }
        public required string CourseName { get; set; }
        public int Score { get; set; }
    }
    public class Programa
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new() { Id = 1, Name = "Alice" },
                new() { Id = 2, Name = "Bob" },
                new() { Id = 3, Name = "Charlie" }
            };

            List<Enrrollment> enrollments = new List<Enrrollment>
            {
                new() { Id = 1, StudentId = 1, CourseName = "Math", Score = 85 },
                new() { Id = 2, StudentId = 1, CourseName = "Science", Score = 90 },
                new() { Id = 3, StudentId = 2, CourseName = "Math", Score = 55 },
                new() { Id = 4, StudentId = 2, CourseName = "Science", Score = 65 },
                new() { Id = 5, StudentId = 2, CourseName = "Programming", Score = 75 },
            };

            var student = students.LeftJoin(
                enrollments,
                s => s.Id,
                e => e.StudentId,
                (s, e) => new
                {
                    StudentName = s.Name,
                    CourseName = e?.CourseName,
                    Score = e?.Score ?? 0,
                    Passing = e?.Score.IsPassing() ?? false
                }).GroupBy(n => n.StudentName);

            foreach (var group in student)
            {
                Console.WriteLine(group.First().CourseName != null ? $" {group.Key} {group.Count()} courses, Passing: {group.Count(e => e.Passing)}, avg score: {group.Average(e => e.Score):F2}." : $"{group.Key} is not enrolled in any course");
            }
        }
    }
}