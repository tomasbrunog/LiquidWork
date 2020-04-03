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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Legajo>(etb =>
            {
                etb.HasMany(l => l.ConceptosFijos).WithOne(c => c.Legajo).OnDelete(DeleteBehavior.Cascade);
                etb.HasMany(l => l.Liquidaciones).WithOne(li => li.Legajo).OnDelete(DeleteBehavior.SetNull);

                etb.HasKey(l => l.NumeroLegajo);
                etb.Property(l => l.FechaIngreso).HasColumnType("date");

            });

            builder.Entity<Liquidacion>()
                .HasMany(li => li.Conceptos)
                .WithOne(c => c.Liquidacion)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Liquidacion>(etb =>
            //{
            //    etb.Property(li => li.TotalRemunerativo).HasColumnType("money");
            //    etb.Property(li => li.TotalNoRemunerativo).HasColumnType("money");
            //    etb.Property(li => li.TotalDeducciones).HasColumnType("money");
            //    etb.Property(li => li.Neto).HasColumnType("money");
            //});

            //Data seeding
            builder.Seed();

            base.OnModelCreating(builder);
        }

        
        }


    }



