﻿// <auto-generated />
using System;
using LiquidWork.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LiquidWork.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiquidWork.Core.Model.Concepto", b =>
                {
                    b.Property<int>("ConceptoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<int>("CodigoConcepto")
                        .HasColumnType("int");

                    b.Property<int>("LiquidacionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal (18,2)");

                    b.Property<string>("NombreConcepto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoConcepto")
                        .HasColumnType("int");

                    b.HasKey("ConceptoId");

                    b.HasIndex("LiquidacionId");

                    b.ToTable("Conceptos");
                });

            modelBuilder.Entity("LiquidWork.Core.Model.Legajo", b =>
                {
                    b.Property<int>("NumeroLegajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long>("CUIL")
                        .HasColumnType("bigint");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("NumeroLegajo");

                    b.ToTable("Legajos");

                    b.HasData(
                        new
                        {
                            NumeroLegajo = 1,
                            Apellido = "Shakespeare",
                            CUIL = 20356568524L,
                            Categoria = "Auxiliar A",
                            FechaIngreso = new DateTime(2012, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "William"
                        },
                        new
                        {
                            NumeroLegajo = 2,
                            Apellido = "Picapiedra",
                            CUIL = 20355455244L,
                            Categoria = "Auxiliar B",
                            FechaIngreso = new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Pedro"
                        },
                        new
                        {
                            NumeroLegajo = 3,
                            Apellido = "Perez",
                            CUIL = 20355455524L,
                            Categoria = "Auxiliar B",
                            FechaIngreso = new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Julio"
                        },
                        new
                        {
                            NumeroLegajo = 4,
                            Apellido = "Ramirez",
                            CUIL = 20355485524L,
                            Categoria = "Auxiliar C",
                            FechaIngreso = new DateTime(2014, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Carlos"
                        },
                        new
                        {
                            NumeroLegajo = 5,
                            Apellido = "Gonzalez",
                            CUIL = 23355455526L,
                            Categoria = "Auxiliar B",
                            FechaIngreso = new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Rosa"
                        },
                        new
                        {
                            NumeroLegajo = 6,
                            Apellido = "Perez",
                            CUIL = 23355342526L,
                            Categoria = "Auxiliar A",
                            FechaIngreso = new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Samanta"
                        },
                        new
                        {
                            NumeroLegajo = 7,
                            Apellido = "Gomez",
                            CUIL = 23387455263L,
                            Categoria = "Auxiliar C",
                            FechaIngreso = new DateTime(2018, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Eugenia"
                        },
                        new
                        {
                            NumeroLegajo = 8,
                            Apellido = "Fernandez",
                            CUIL = 20235545524L,
                            Categoria = "Auxiliar E",
                            FechaIngreso = new DateTime(2010, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Julian"
                        },
                        new
                        {
                            NumeroLegajo = 9,
                            Apellido = "Smith",
                            CUIL = 23366845526L,
                            Categoria = "Auxiliar B",
                            FechaIngreso = new DateTime(2009, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Estela"
                        },
                        new
                        {
                            NumeroLegajo = 10,
                            Apellido = "Candia",
                            CUIL = 23335555526L,
                            Categoria = "Auxiliar B",
                            FechaIngreso = new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Mariana"
                        });
                });

            modelBuilder.Entity("LiquidWork.Core.Model.Liquidacion", b =>
                {
                    b.Property<int>("LiquidacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Neto")
                        .HasColumnType("decimal (18,2)");

                    b.Property<int?>("NumeroLegajo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Periodo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalDeducciones")
                        .HasColumnType("decimal (18,2)");

                    b.Property<decimal>("TotalNoRemunerativo")
                        .HasColumnType("decimal (18,2)");

                    b.Property<decimal>("TotalRemunerativo")
                        .HasColumnType("decimal (18,2)");

                    b.HasKey("LiquidacionId");

                    b.HasIndex("NumeroLegajo");

                    b.ToTable("Liquidaciones");
                });

            modelBuilder.Entity("LiquidWork.Core.Model.Concepto", b =>
                {
                    b.HasOne("LiquidWork.Core.Model.Liquidacion", "Liquidacion")
                        .WithMany("Conceptos")
                        .HasForeignKey("LiquidacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LiquidWork.Core.Model.Liquidacion", b =>
                {
                    b.HasOne("LiquidWork.Core.Model.Legajo", "Legajo")
                        .WithMany("Liquidaciones")
                        .HasForeignKey("NumeroLegajo")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
