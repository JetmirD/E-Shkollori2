using MessagePack;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class Shkolla
    {
        [Key]
        public int ShkollaId { get; set; }



        [Required(ErrorMessage = "Duhet te caktohet emri i shkolles")]
        public string? EmriShkolles { get; set; }

        public string? SelectedLlojiShkolles { get; set; }


        [Required(ErrorMessage = "Duhet te caktohet lloji i shkolles")]
        [ReadOnly(true)]
        public List<string> LlojiShkolles
        {
            get
            {
                return new List<string> { "Shkolla Fillore", "Shkolla e Mesme" };
            }
        }

    }
}
