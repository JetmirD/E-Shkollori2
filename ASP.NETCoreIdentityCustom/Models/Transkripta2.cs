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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int TranskriptaId { get; set; }




        public List<ApplicationUser>? User { get; set; }
        [Range(5, 10)]
        public int Nota { get; set; }

        [Range(0, 15)]
        public int Credits { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;




        public int LendaId { get; set; }


        public virtual Lenda2? Lenda { get; set; }
        public virtual ApplicationUser? Studenti { get; set; }
    }
}