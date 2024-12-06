using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MailroomApplication.Models;

public class Staff
{
    public int staffID {get; set;}
    [Required]
    [Display(Name = "Username")]
    public string username {get; set;} = default!;
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string password {get; set;} = default!;
    [Display(Name = "Remember Me?")]
    public bool RememberMe {get; set;} = true;
}