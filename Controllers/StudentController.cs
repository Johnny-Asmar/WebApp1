using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Abstraction;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/Students")]
public class StudentController : ControllerBase
{
    
    

    List<Student> StudentList = new List<Student>();

    private IStudentHelper _studentHelper;
    
    public StudentController(IStudentHelper studentHelper)
    {
        Student stud1 = new Student();
        Student stud2 = new Student();
        Student stud3 = new Student();
        
        stud1.Id = 1;
        stud1.name = "Johnny";
        stud1.email = "Johnny.asmar@hotmail.com";
        
        stud2.Id = 2;
        stud2.name = "Charbel";
        stud2.email = "Charbel.asmar@hotmail.com";
        
        stud3.Id = 3;
        stud3.name = "John";
        stud3.email = "John.asmar@hotmail.com";
        
        StudentList.Add(stud1);
        StudentList.Add(stud2);
        StudentList.Add(stud3);

        _studentHelper = studentHelper;
        



    }

    // GET: api/Students
    [HttpGet()]
    public async Task<List<Student>> GetStudents()
    {
        return _studentHelper.ListStudents(StudentList);
    }

    [HttpPost()]
    public async Task<List<Student>> AddStudent([FromBody] Student student)
    {
        return _studentHelper.AddStudent(StudentList, student);
    }


    [HttpGet("{Id:Long}")]

    public async Task<Student> GetStudent([FromRoute] int Id)
    {
        return _studentHelper.GetStudentbyId(StudentList, Id);
    }
    
    [HttpGet("GetbyName")]
    
    public async Task<List<Student>> GetStudentbyName([FromQuery] string name)
    {
        return _studentHelper.NameContains(StudentList, name);
    }
    
    [HttpGet("GetDate")]
    
    public async Task <string> GetDateforLang([FromQuery] string lang)
    {
        return _studentHelper.DateBase(lang);
    }
    
    [HttpPost("{id:int}")]
    public async Task <Student> ChangeStudent([FromRoute] int id, string name)
    {
        return _studentHelper.ChangeNameStudent(StudentList, id, name);
    }
    
}