using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailroomApplication.Models
{
    public class ResidentPackage 
    {
        [Key]
        [ForeignKey("Resident")]
        public int residentID {get; set;}
        [ForeignKey("Package")]
        public int packageID {get; set;}

        public virtual Resident Resident {get; set;}
        public virtual Package Package {get; set;}
    }
}