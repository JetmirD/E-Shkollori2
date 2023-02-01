using MessagePack;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class Lenda2
    {
        [Key]
        public int LendaId { get; set; }

        [Required(ErrorMessage ="Duhet te shenohet nje emer i Lendes")]
        public string? EmriLendes { get; set; }

        //Kjo na nevojitet per arsye qe mu rujt Lloji i lendes per cdo emer te lendes
        public string? SelectedLlojiLendes { get; set; }


        //Kjo eshte nje liste statike per kete arsye nuk kemi {get;set} dhe na shfaqen vetem keto dy te dhana ne liste
        [Required(ErrorMessage ="Duhet te caktohet lloji i lendes")]
        [ReadOnly(true)]
        public List<string> LlojiLendes
        {
            get
            {
                return new List<string> { "E rregullt", "Zgjedhore" };
            }
        }
    }

}
