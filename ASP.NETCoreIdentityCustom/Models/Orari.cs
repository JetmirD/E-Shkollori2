using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class Orari

    {
        [Key]
        public int OrariId { get; set; }
        public int LendaId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MMM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Koha { get; set; }
        [Required]

        [Range(1,12,ErrorMessage ="Shtypni klasat nga 1 deri 12")]
        
        public int? Klasa { get; set; }
        

        public virtual Lenda2? Lenda { get; set; }

        internal static Orari Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
