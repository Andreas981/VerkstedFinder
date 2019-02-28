using Microsoft.EntityFrameworkCore;
using VerkstedFinder.Model;

namespace VerkstedFinder.Context
{
    public partial class AndremiContext : DbContext
    {

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Poststed> Poststeds { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workshop> Workshops { get; set; }


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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Donau.hiof.no;Database=andremi;Trusted_Connection=False;user id=andremi;pwd=WteZqW6T;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId, rp.PermId });

            base.OnModelCreating(modelBuilder);
        
    }
    }
}
