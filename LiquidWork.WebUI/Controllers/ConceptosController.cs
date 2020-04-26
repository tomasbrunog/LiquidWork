using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using LiquidWork.Services;
using LiquidWork.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidWork.WebUI.Controllers
{
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
            return View(await _context.Conceptos.ToListAsync());
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

            return View(concepto);
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
                    Monto = vm.Monto,
                    Cantidad = vm.Cantidad,
                    TipoConcepto = (TipoConcepto)vm.TipoConcepto,
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
                Monto = concepto.Monto,
                Cantidad = concepto.Cantidad,
                TipoConcepto = (int)concepto.TipoConcepto,
                LiquidacionId = (int)concepto.LiquidacionId
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
                    concepto.Monto = vm.Monto;
                    concepto.Cantidad = vm.Cantidad;
                    concepto.TipoConcepto = (TipoConcepto)vm.TipoConcepto;

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
