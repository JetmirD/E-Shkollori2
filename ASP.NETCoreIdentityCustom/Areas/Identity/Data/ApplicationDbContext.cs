using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASP.NETCoreIdentityCustom.Models;

namespace ASP.NETCoreIdentityCustom.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    public DbSet<ASP.NETCoreIdentityCustom.Models.Studenti> Studenti { get; set; }

    public DbSet<ASP.NETCoreIdentityCustom.Models.Mesuesi> Mesuesi { get; set; }

    public DbSet<ASP.NETCoreIdentityCustom.Models.Transkripta> Transkripta { get; set; }

    public DbSet<ASP.NETCoreIdentityCustom.Models.Lenda> Lenda { get; set; }

    public DbSet<ASP.NETCoreIdentityCustom.Models.testi> testi { get; set; }

    public DbSet<ASP.NETCoreIdentityCustom.Models.Lenda2> Lenda2 { get; set; }

    public DbSet<ASP.NETCoreIdentityCustom.Models.Transkripta2> Transkripta2 { get; set; }

    public DbSet<ASP.NETCoreIdentityCustom.Models.Orari> Orari { get; set; }

    public DbSet<ASP.NETCoreIdentityCustom.Models.Shkolla> Shkolla { get; set; }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}
