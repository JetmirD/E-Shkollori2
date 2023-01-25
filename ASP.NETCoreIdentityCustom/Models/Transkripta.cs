using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class Transkripta
    {
        public int Id { get; set; }
        public List<ApplicationUser>? User { get; set; }
        public string SelectedUserId { get; set; }

        public List<Lenda>? Lenda { get; set; }
        public int Nota { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
    }

}
