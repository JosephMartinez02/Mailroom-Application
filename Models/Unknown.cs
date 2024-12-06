using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailroomApplication.Models;

public class Unknown
{
    public int unknownID {get; set;}
    [Display(Name = "Package #")]
    public int packageID {get; set;}
    public virtual Package? Package {get; set;}
}