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

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (!(obj is Student))
        {
            return false;
        }

        return this.Id == ((Student)obj).Id && this.name == ((Student)obj).name && this.email == ((Student)obj).email;
    }
    
}