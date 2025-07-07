using Microsoft.EntityFrameworkCore;
using PMB_Backend.Models;

using Microsoft.EntityFrameworkCore;
using PMB_Backend.Models;

namespace PMB_Backend.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Mahasiswa> Mahasiswas { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mahasiswa>(entity =>
            {
                entity.HasIndex(m => m.Email).IsUnique();
                entity.Property(m => m.NamaLengkap).IsRequired();
                entity.Property(m => m.Email).IsRequired();
                entity.Property(m => m.PasswordHash).IsRequired();
            });
        }
    }
}
            
 