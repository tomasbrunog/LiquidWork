using LiquidWork.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace LiquidWork.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }



        public DbSet<Legajo> Legajos { get; set; }
        public DbSet<Liquidacion> Liquidaciones { get; set; }
        public DbSet<Concepto> Conceptos { get; set; }
        public DbSet<ItemConcepto> ItemsConcepto { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SueldoBasico>();
            builder.Entity<Antiguedad>();
            builder.Entity<Presentismo>();
            builder.Entity<Feriado>();
            builder.Entity<HorasExtra>();
            builder.Entity<FaltasInjustificadas>();
            builder.Entity<Jubilacion>();
            builder.Entity<Pami>();
            builder.Entity<ObraSocial>();
            builder.Entity<Sindicato>();

            builder.Entity<Legajo>(etb =>
            {
                etb.HasMany(l => l.ConceptosFijos).WithOne(c => c.Legajo).OnDelete(DeleteBehavior.Cascade);
                etb.HasMany(l => l.Liquidaciones).WithOne(li => li.Legajo).OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<Liquidacion>()
                .HasMany(li => li.Conceptos)
                .WithOne(c => c.Liquidacion)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Liquidacion>(etb =>
            {
                etb.Property(li => li.TotalDeducciones).HasColumnType("decimal (9,2)");
                etb.Property(li => li.TotalRemunerativo).HasColumnType("decimal (9,2)");
                etb.Property(li => li.TotalNoRemunerativo).HasColumnType("decimal (9,2)");
                etb.Property(li => li.Neto).HasColumnType("decimal (9,2)");
            });

            builder.Entity<Concepto>().HasKey(c => c.CodigoConcepto);

            builder.Entity<ItemConcepto>()
                .Property(c => c.Monto)
                .HasColumnType("decimal (9,2)");

            base.OnModelCreating(builder);
        }

            


    }

}

