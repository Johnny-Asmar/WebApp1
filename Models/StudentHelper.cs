using WebApplication1.Abstraction;

namespace WebApplication1.Models;

public class StudentHelper : IStudentHelper

{
    public Student GetStudentbyId(List<Student> Students, int id)
    {
        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].Id == id)
                return Students[i];
            else
            {
                Console.WriteLine("Student not found");
            }
        }

        return null;
    }

    public List<Student> ListStudents(List<Student> students)
    {
        return students;
    }

    public List<Student> AddStudent(List<Student> students, Student stud)
    {
        students.Add(stud);
        return students;
    }

    public List<Student> NameContains(List<Student> students, string name)
    {
        List<Student> studentName = new List<Student>();
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].name.Contains(name))
                studentName.Add(students[i]);
        }
        if (studentName.Count == 0)
        {
            Console.WriteLine("Students not found in this name");
        }
        return studentName;
    }
    
}
