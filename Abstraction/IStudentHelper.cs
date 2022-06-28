using WebApplication1.Models;

namespace WebApplication1.Abstraction;

public interface IStudentHelper
{
     public Student GetStudentbyId(List<Student> Students, int Id);
     
     public  List<Student> ListStudents(List<Student> Students);
     
     public List<Student> AddStudent(List<Student> Students, Student student);

     public List<Student> NameContains(List<Student> Students, string name);

     public string DateBase(string language);

     public Student ChangeNameStudent(List<Student> Students, int id, string name);
}