using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MailroomApplication.Models;

public class Package
{
    public int packageID {get; set;}
    [Display(Name = "Postal Service")]
    public string? postalService {get; set;}
    [Display(Name = "Checked In")]
    public DateTime checkInDate {get; set;}
    [Display(Name = "Checked Out")]
    public DateTime? checkOutDate {get; set;}
    [Display(Name = "Current Status")]
    public string? status {get; set;}
    [Display(Name = "Resident Full Name")]
    public string? residentName {get; set;}
    [Display(Name = "Unit #")]
    public int unitNumber {get; set;}
    [EmailAddress]
    [Display(Name = "E-Mail")]
    public string? email {get; set;}
    public Resident Resident {get; set;} = default!;
}