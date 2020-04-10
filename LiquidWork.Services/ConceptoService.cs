﻿using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquidWork.Services
{
    public class ConceptoService
    {
        private readonly DataContext _context;

        public ConceptoService(DataContext context)
        {
            _context = context;
        }
        public void AddConcepto(Concepto concepto) => _context.Add(concepto);
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
