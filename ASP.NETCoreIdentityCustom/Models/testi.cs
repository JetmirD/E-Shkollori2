using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using MessagePack;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class testi
    {
        [Key]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get { return FirstName + " " + LastName; } }

        public static explicit operator testi(ApplicationUser user)
        {
            return new testi
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
