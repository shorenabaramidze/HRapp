using HRapplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRapplication.Areas.Identity.Data;

public class HRapplicationContext : IdentityDbContext<HRapplicationUser>
{
    public HRapplicationContext(DbContextOptions<HRapplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<HRapplicationUser>
    {
        public void Configure(EntityTypeBuilder<HRapplicationUser> builder)
        {
            builder.Property(u => u.IdNumber).HasMaxLength(11);
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.Property(u => u.Gender).HasMaxLength(10);
            builder.Property(u => u.BirthDate).HasMaxLength(30);

        }
    }

}
