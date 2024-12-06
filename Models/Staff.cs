using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MailroomApplication.Models;

public class Staff
{
    [Required]
    [EmailAddress]
    [Display(Name = "E-Mail")]
    public string email {get; set;}
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string password {get; set;}
    [Display(Name = "Remember Me?")]
    public bool RememberMe {get; set;}
}