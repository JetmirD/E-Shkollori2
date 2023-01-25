using System.Collections.Generic;
using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NETCoreIdentityCustom.Core.ViewModels
{
    public class VleresimiViewModel
    {
        public List<Lenda> Lendet { get; set; }
        public List<ApplicationUser> Studentet { get; set; }
        public string Emri { get; set; }
        public SelectList UserSelectList { get; set; }

        public int? Nota { get; set; }
        public int? StudentId { get; set; }
        public int? LendaId { get; set; }
        public string UserId { get; set; }

    }
}
