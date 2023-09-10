using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace EmailServiceProject.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Mail> Mails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //The same e-mail address cannot be created more than once.
            modelBuilder.Entity<User>().HasIndex(x => x.emailAdress).IsUnique();
     
            //Specifies the default value for the fromEmail property.
            modelBuilder.Entity<Mail>().Property(e => e.fromEmail).HasDefaultValue("merveu@ssttek.com");
    
        }

    }
}
