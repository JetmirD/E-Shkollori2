

using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class TranskriptaWithFullNameAndLenda
    {
        public int TranskriptaId { get; set; }
        public int Nota { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }
        public string? FullName { get; set; }
        public Lenda2? Lenda { get; set; }
    }

}
