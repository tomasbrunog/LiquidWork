using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiquidWork.Core.Model;
using LiquidWork.Persistence;

namespace LiquidWork.WebUI.Controllers
{
    public class ConceptosController : Controller
    {
        private readonly DataContext _context;

        public ConceptosController(DataContext context)
        {
            _context = context;
        }

        // GET: Conceptos
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Conceptos.Include(c => c.Legajo).Include(c => c.Liquidacion);
            return View(await dataContext.ToListAsync());
        }

        // GET: Conceptos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Conceptos
                .Include(c => c.Legajo)
                .Include(c => c.Liquidacion)
                .FirstOrDefaultAsync(m => m.ConceptoId == id);
            if (concepto == null)
            {
                return NotFound();
            }

            return View(concepto);
        }

        // GET: Conceptos/Create
        public IActionResult Create()
        {
            ViewData["LegajoId"] = new SelectList(_context.Legajos, "LegajoId", "Apellido");
            ViewData["LiquidacionId"] = new SelectList(_context.Liquidaciones, "LiquidacionId", "LiquidacionId");
            return View();
        }

        // POST: Conceptos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConceptoId,CodigoConcepto,Unidad,Precedencia,Monto,LiquidacionId,LegajoId,TipoConcepto")] ItemConcepto concepto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concepto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LegajoId"] = new SelectList(_context.Legajos, "LegajoId", "Apellido", concepto.LegajoId);
            ViewData["LiquidacionId"] = new SelectList(_context.Liquidaciones, "LiquidacionId", "LiquidacionId", concepto.LiquidacionId);
            return View(concepto);
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
            ViewData["LegajoId"] = new SelectList(_context.Legajos, "LegajoId", "Apellido", concepto.LegajoId);
            ViewData["LiquidacionId"] = new SelectList(_context.Liquidaciones, "LiquidacionId", "LiquidacionId", concepto.LiquidacionId);
            return View(concepto);
        }

        // POST: Conceptos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConceptoId,CodigoConcepto,Unidad,Precedencia,Monto,LiquidacionId,LegajoId,TipoConcepto")] ItemConcepto concepto)
        {
            if (id != concepto.ConceptoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concepto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConceptoExists(concepto.ConceptoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LegajoId"] = new SelectList(_context.Legajos, "LegajoId", "Apellido", concepto.LegajoId);
            ViewData["LiquidacionId"] = new SelectList(_context.Liquidaciones, "LiquidacionId", "LiquidacionId", concepto.LiquidacionId);
            return View(concepto);
        }

        // GET: Conceptos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Conceptos
                .Include(c => c.Legajo)
                .Include(c => c.Liquidacion)
                .FirstOrDefaultAsync(m => m.ConceptoId == id);
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
            _context.Conceptos.Remove(concepto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConceptoExists(int id)
        {
            return _context.Conceptos.Any(e => e.ConceptoId == id);
        }
    }
}
