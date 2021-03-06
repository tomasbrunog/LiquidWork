﻿using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using LiquidWork.Services;
using LiquidWork.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidWork.WebUI.Controllers
{
    [Authorize]
    public class ConceptosController : Controller
    {
        private readonly DataContext _context;
        private readonly ConceptoService _conceptoService;

        public ConceptosController(DataContext context)
        {
            _context = context;
            _conceptoService = new ConceptoService(_context);
        }

        // GET: Conceptos
        public async Task<IActionResult> Index()
        {
            var conceptoCollection = await _context.Conceptos.ToListAsync();
            var conceptoViewModelCollection = new List<ConceptoViewModel>();

            foreach (var concepto in conceptoCollection)
            {
                var viewModel = new ConceptoViewModel
                {
                    ConceptoId = concepto.ConceptoId,
                    CodigoConcepto = concepto.CodigoConcepto,
                    NombreConcepto = concepto.NombreConcepto,
                    Monto = concepto.BaseMonto,
                    Porcentaje = (int)(concepto.Factor * 100),
                    Posicion = concepto.Posicion,
                    TipoConcepto = concepto.TipoConcepto,
                    LiquidacionId = concepto.LiquidacionId
                };

                conceptoViewModelCollection.Add(viewModel);
            }
            return View(conceptoViewModelCollection);
        }

        // GET: Conceptos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Conceptos
                .FirstOrDefaultAsync(m => m.ConceptoId == id);
            if (concepto == null)
            {
                return NotFound();
            }

            var viewModel = new ConceptoViewModel
            {
                ConceptoId = concepto.ConceptoId,
                CodigoConcepto = concepto.CodigoConcepto,
                NombreConcepto = concepto.NombreConcepto,
                Monto = concepto.BaseMonto,
                Porcentaje = (int)(concepto.Factor * 100),
                Posicion = concepto.Posicion,
                TipoConcepto = concepto.TipoConcepto,
                LiquidacionId = concepto.LiquidacionId,
                Legajo = new LegajoConcepto
                {
                    NumeroLegajo = concepto.Liquidacion.Legajo.NumeroLegajo,
                    Nombre = concepto.Liquidacion.Legajo.Nombre,
                    Apellido = concepto.Liquidacion.Legajo.Apellido
                }
            };

            return View(viewModel);
        }

        // GET: Conceptos/Create
        public IActionResult Create(int? liquidacionId)
        {
            TempData["LiquidacionId"] = liquidacionId;
            return View();
        }

        // POST: Conceptos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConceptoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var concepto = new Concepto
                {
                    CodigoConcepto = vm.CodigoConcepto,
                    NombreConcepto = vm.NombreConcepto,
                    BaseMonto = vm.Monto,
                    Factor = vm.Porcentaje / 100M,
                    Posicion = vm.Posicion ?? 0,
                    TipoConcepto = vm.TipoConcepto,
                    LiquidacionId = vm.LiquidacionId
                };

                _conceptoService.AddConcepto(concepto);
                await _conceptoService.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Liquidaciones", new { id = concepto.LiquidacionId });
            }
            return View(vm);
        }

        // GET: Conceptos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Conceptos.FindAsync(id);
            if (concepto == null)
            {
                return NotFound();
            }

            var viewModel = new ConceptoViewModel
            {
                ConceptoId = concepto.ConceptoId,
                CodigoConcepto = concepto.CodigoConcepto,
                NombreConcepto = concepto.NombreConcepto,
                Monto = concepto.BaseMonto,
                Porcentaje = (int)(concepto.Factor * 100),
                Posicion = concepto.Posicion,
                TipoConcepto = concepto.TipoConcepto,
                LiquidacionId = concepto.LiquidacionId
            };

            return View(viewModel);
        }

        // POST: Conceptos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConceptoViewModel vm)
        {
            if (id != vm.ConceptoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var concepto = _context.Conceptos.Find(vm.ConceptoId);

                    concepto.CodigoConcepto = vm.CodigoConcepto;
                    concepto.NombreConcepto = vm.NombreConcepto;
                    concepto.BaseMonto = vm.Monto;
                    concepto.Factor = vm.Porcentaje / 100M;
                    concepto.Posicion = vm.Posicion ?? 0;
                    concepto.TipoConcepto = vm.TipoConcepto;

                    _conceptoService.UpdateConcepto(concepto);
                    await _conceptoService.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConceptoExists(vm.ConceptoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Liquidaciones", new { id = vm.LiquidacionId });
            }
            return View(vm);
        }

        // GET: Conceptos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Conceptos
                .FirstOrDefaultAsync(c => c.ConceptoId == id);
            if (concepto == null)
            {
                return NotFound();
            }

            return View(concepto);
        }

        // POST: Conceptos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concepto = await _context.Conceptos.FindAsync(id);
            _conceptoService.DeleteConcepto(concepto);
            await _conceptoService.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Liquidaciones", new { id = concepto.LiquidacionId });
        }

        private bool ConceptoExists(int id)
        {
            return _context.Conceptos.Any(e => e.ConceptoId == id);
        }
    }
}
