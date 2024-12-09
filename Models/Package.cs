using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MailroomApplication.Models;

public class Package
{
    [Display(Name = "Package #")]
    public int packageID {get; set;}
    [Display(Name = "Postal Service")]
    [Required]
    public string? postalService {get; set;}
    [Display(Name = "Checked In")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime checkInDate {get; set;}
    [Display(Name = "Checked Out")]
    [DataType(DataType.Date)]
    public DateTime? checkOutDate {get; set;}
    [Display(Name = "Current Status")]
    [Required]
    public string status {get; set;} = default!;
    [Display(Name = "Resident Name")]
    public int residentID {get; set;}
    public virtual Resident? Resident {get; set;}
    public List<ResidentPackage> ResidentPackages {get; set;} = [];
    public List<Unknown> Unknowns {get; set;} = [];
}