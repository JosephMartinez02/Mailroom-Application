using System.ComponentModel.DataAnnotations;

namespace MailroomApplication.Models;

public class Resident
{
    public int residentID {get; set;}
    [Required]
    [Display(Name = "Name")]
    public string? residentName {get; set;}
    [Required]
    [Display(Name = "Unit #")]
    public int unitNumber {get; set;}
    [Required]
    [EmailAddress]
    [Display(Name = "E-Mail Address")]
    public string? email {get; set;}
}