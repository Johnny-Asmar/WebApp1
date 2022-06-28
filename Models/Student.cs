using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Student
{
    [Required (ErrorMessage="Please enter your Id")]
    public long Id { get; set; }
    [Required (ErrorMessage="Please enter your Name")] 
    public string name{ get; set; }
    [Required (ErrorMessage="Please enter your Id")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string email{ get; set; }

    
    
}