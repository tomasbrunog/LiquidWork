﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LiquidWork.Core.Model
{
    public class SueldoBasico : Concepto
    {
        public override double CalcularMonto()
        {
            throw new NotImplementedException();
        }
    }
}
