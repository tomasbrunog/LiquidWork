using LiquidWork.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace LiquidWork.Persistence
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Legajo>().HasData(
                new Legajo { NumeroLegajo = 1, Nombre = "William", Apellido = "Shakespeare", CUIL = 20356568524, Categoria = "Auxiliar A", FechaIngreso = new DateTime(2012, 6, 25) },
                new Legajo { NumeroLegajo = 2, Nombre = "Pedro", Apellido = "Picapiedra", CUIL = 20355455244, Categoria = "Auxiliar B", FechaIngreso = new DateTime(2013, 7, 2) },
                new Legajo { NumeroLegajo = 3, Nombre = "Julio", Apellido = "Perez", CUIL = 20355455524, Categoria = "Auxiliar B", FechaIngreso = new DateTime(2013, 7, 2) },
                new Legajo { NumeroLegajo = 4, Nombre = "Carlos", Apellido = "Ramirez", CUIL = 20355485524, Categoria = "Auxiliar C", FechaIngreso = new DateTime(2014, 11, 21) },
                new Legajo { NumeroLegajo = 5, Nombre = "Rosa", Apellido = "Gonzalez", CUIL = 23355455526, Categoria = "Auxiliar B", FechaIngreso = new DateTime(2018, 9, 12) },
                new Legajo { NumeroLegajo = 6, Nombre = "Samanta", Apellido = "Perez", CUIL = 23355342526, Categoria = "Auxiliar A", FechaIngreso = new DateTime(2018, 9, 12) },
                new Legajo { NumeroLegajo = 7, Nombre = "Eugenia", Apellido = "Gomez", CUIL = 23387455263, Categoria = "Auxiliar C", FechaIngreso = new DateTime(2018, 7, 2) },
                new Legajo { NumeroLegajo = 8, Nombre = "Julian", Apellido = "Fernandez", CUIL = 20235545524, Categoria = "Auxiliar E", FechaIngreso = new DateTime(2010, 4, 12) },
                new Legajo { NumeroLegajo = 9, Nombre = "Estela", Apellido = "Smith", CUIL = 23366845526, Categoria = "Auxiliar B", FechaIngreso = new DateTime(2009, 5, 29) },
                new Legajo { NumeroLegajo = 10, Nombre = "Mariana", Apellido = "Candia", CUIL = 23335555526, Categoria = "Auxiliar B", FechaIngreso = new DateTime(2011, 6, 15) }
            );

            builder.Entity<Concepto>().HasData(
                new Concepto { ConceptoId = 30, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 35500, NumeroLegajo = 1, LiquidacionId = null },
                new Concepto { ConceptoId = 11, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 35500, NumeroLegajo = 2, LiquidacionId = null },
                new Concepto { ConceptoId = 12, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 37000, NumeroLegajo = 3, LiquidacionId = null },
                new Concepto { ConceptoId = 13, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 80500, NumeroLegajo = 4, LiquidacionId = null },
                new Concepto { ConceptoId = 14, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 43000, NumeroLegajo = 5, LiquidacionId = null },
                new Concepto { ConceptoId = 15, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 35500, NumeroLegajo = 6, LiquidacionId = null },
                new Concepto { ConceptoId = 16, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 68600, NumeroLegajo = 7, LiquidacionId = null },
                new Concepto { ConceptoId = 17, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 44000, NumeroLegajo = 8, LiquidacionId = null },
                new Concepto { ConceptoId = 18, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 33900, NumeroLegajo = 9, LiquidacionId = null },
                new Concepto { ConceptoId = 19, CodigoConcepto = 101, NombreConcepto = "Sueldo basico", TipoConcepto = TipoConcepto.Remunerativo, Cantidad = 0, Monto = 44600, NumeroLegajo = 10, LiquidacionId = null },

                new Concepto { ConceptoId = 20, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 1, LiquidacionId = null },
                new Concepto { ConceptoId = 21, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 2, LiquidacionId = null },
                new Concepto { ConceptoId = 22, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 3, LiquidacionId = null },
                new Concepto { ConceptoId = 23, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 4, LiquidacionId = null },
                new Concepto { ConceptoId = 24, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 5, LiquidacionId = null },
                new Concepto { ConceptoId = 25, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 6, LiquidacionId = null },
                new Concepto { ConceptoId = 26, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 7, LiquidacionId = null },
                new Concepto { ConceptoId = 27, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 8, LiquidacionId = null },
                new Concepto { ConceptoId = 28, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 9, LiquidacionId = null },
                new Concepto { ConceptoId = 29, CodigoConcepto = 201, NombreConcepto = "Jubilacion", TipoConcepto = TipoConcepto.Deduccion, Cantidad = 11, Monto = 0, NumeroLegajo = 10, LiquidacionId = null }

            );

        }
    }
}
