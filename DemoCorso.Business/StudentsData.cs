using System.Collections.ObjectModel;

namespace DemoCorso.Business
{
    public class StudentsData
    {
        public ObservableCollection<Student> Students { get; set; } = new();

        public StudentsData()
        {
            Students.Add(new Student() { Id = 1, Name = "Mario", Surname = "Rossi" });
            Students.Add(new Student() { Id = 2, Name = "Luigi", Surname = "Bianchi" });
            Students.Add(new Student() { Id = 3, Name = "Giuseppe", Surname = "Verdi" });
        }

        public void AddStudent()
        {
            Students.Add(new Student { Id = 4, Name = "Pippo", Surname = "Poppo" });
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}