using System.ComponentModel.DataAnnotations;

namespace MailroomApplication.Models;

public class Unknown
{
    public int unknownID {get; set;}
    public int packageID {get; set;}
    public Package Package {get; set;} = default!;
}