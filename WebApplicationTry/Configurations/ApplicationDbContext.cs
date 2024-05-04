using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationTry.Models;

namespace WebApplicationTry.Configurations
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("Users");  
              
                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(u => u.Name).IsRequired();

                entity.Property(u => u.RegistrationDate).IsRequired();
                entity.Property(u => u.LastLoginDate).IsRequired(false);
                entity.Property(u => u.IsBlocked).IsRequired().HasDefaultValue(false);

                entity.Property(u => u.Email).HasMaxLength(256);  
            });
        }
    }
}

