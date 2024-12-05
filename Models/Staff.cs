using System.ComponentModel.DataAnnotations;

namespace MailroomApplication.Models;

public class Staff
{
    public int staffID {get; set;}
    [Required]
    public string? username {get; set;}
    [Required]
    public string? password {get; set;}
}