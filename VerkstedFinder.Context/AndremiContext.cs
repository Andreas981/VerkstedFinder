using Microsoft.EntityFrameworkCore;

using VerkstedFinder.Model;

namespace VerkstedFinder.Context
{
    public partial class AndremiContext : DbContext
    {

        public DbSet<Poststed> Poststeds { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<User> Users { get; set; }


        public AndremiContext()
        {
        }

        public AndremiContext(DbContextOptions<AndremiContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Donau.hiof.no;Database=andremi;Trusted_Connection=False;user id=andremi;pwd=WteZqW6T;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            base.OnModelCreating(modelBuilder);
        
        }
    }
}
