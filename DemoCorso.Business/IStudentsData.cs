using System.Collections.ObjectModel;

namespace DemoCorso.Business
{
    public interface IStudentsData
    {
        ObservableCollection<Student> Students { get; set; }
        void AddStudent();
        Student BestStudent { get; set; }
    }
}