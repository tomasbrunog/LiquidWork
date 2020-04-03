﻿using LiquidWork.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiquidWork.Core.Contracts.Services
{
    public interface ILegajoService
    {
        public void Create();
        public void AddConceptoFijo(Legajo legajo, Concepto concepto);
        public void RemoveConceptoFijo(Legajo legajo, Concepto concepto);
        public void AddLiquidacion(Legajo legajo, Liquidacion liquidacion);
        public void RemoveLiquidacion(Legajo legajo, Liquidacion liquidacion);
        
    }
}
