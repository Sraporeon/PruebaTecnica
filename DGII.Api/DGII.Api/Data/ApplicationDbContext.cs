using DGII.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DGII.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Contribuyente> Contribuyentes { get; set; }
        public DbSet<ComprobanteFiscal> ComprobantesFiscales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribuyente>().HasKey(c => c.RncCedula);

            // para evitar duplicados (anotar para futuro)
            modelBuilder.Entity<ComprobanteFiscal>().HasKey(cf => new { cf.RncCedula, cf.NCF });

            modelBuilder.Entity<ComprobanteFiscal>().Property(c => c.Monto).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ComprobanteFiscal>().Property(c => c.Itbis18).HasColumnType("decimal(18,2)");
        }
    }
}