using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using System.Drawing.Drawing2D;
namespace ASP.NETCoreIdentityCustom.Models
{
    public class Transkripta2
    {
        [Key]
        [Display(Name = "Number")]
        public int TranskriptaId { get; set; }



        [Required(ErrorMessage = "Shtypni nje note")]
        [Range(1, 5, ErrorMessage = "Nota duhet te jete nga 1 deri 5")]
        public int Nota { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;



        //Per marrjen e lendeve
        public int LendaId { get; set; }

        //Ky kod sherben per marrjen e te dhenave per cdo user nga ApplicationUser
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public static explicit operator Transkripta2(ApplicationUser user)
        {
            return new Transkripta2
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }


        //Per marrjen e lendeve
        public virtual Lenda2? Lenda { get; set; }
        public virtual ApplicationUser? Studenti { get; set; }
    }
}