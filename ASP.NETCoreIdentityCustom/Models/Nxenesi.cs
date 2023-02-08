using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class Nxenesi
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Duhet te shenohet emri")]
        public string Emri { get; set; }

        [Required(ErrorMessage = "Duhet te shenohet mbiemri")]
        public string Mbiemri { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLindjes { get; set; }

        [Required(ErrorMessage = "Duhet te shenohet numri i telefonit")]
        public string NumriTelefonit { get; set; }
       
        public int? ShkollaId { get; set; }
        [ForeignKey("ShkollaId ")]
        public Shkolla? Shkolla { get; set; }



    }
}
