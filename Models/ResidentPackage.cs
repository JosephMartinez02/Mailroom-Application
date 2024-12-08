using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailroomApplication.Models
{
    public class ResidentPackage 
    {
        public int residentID {get; set;}
        public int packageID {get; set;}

        public Resident Resident {get; set;} = default!;
        public Package Package {get; set;} = default!;
    }
}