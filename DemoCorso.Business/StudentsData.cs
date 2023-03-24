using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DemoCorso.Business
{
    public class StudentsData : IStudentsData
    {
        public ObservableCollection<Student> Students { get; set; } = new();
        public Student BestStudent { get; set; } = new();

        public StudentsData()
        {
            Students.Add(new Student() { Id = 1, Name = "Mario", Surname = "Rossi" });
            Students.Add(new Student() { Id = 2, Name = "Luigi", Surname = "Bianchi" });
            Students.Add(new Student() { Id = 3, Name = "Giuseppe", Surname = "Verdi" });
            BestStudent = Students.First();
        }

        public void AddStudent()
        {
            Students.Add(new Student { Id = 4, Name = "Pippo", Surname = "Poppo" });
        }
    }

    public class Student: INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name = string.Empty;
        public string Name { 
            get { return name; }
            set { 
                if(value != name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            } 
        }

        private string surname = string.Empty;
        public string Surname { 
            get { return surname; }
            set { 
                if(value != surname)
                {
                    surname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}