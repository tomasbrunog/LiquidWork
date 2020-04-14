using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using LiquidWork.Services;
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
                .Include(c=>c.Legajo)
                .FirstOrDefaultAsync(m => m.ConceptoId == id);
            if (concepto == null)
            {
                return NotFound();
            }

            return View(concepto);
        }

        // GET: Conceptos/Create
        public IActionResult Create(int? numeroLegajo, int? liquidacionId)
        {
            TempData["NumeroLegajo"] = numeroLegajo;
            TempData["LiquidacionId"] = liquidacionId;
            return View();
        }

        // POST: Conceptos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroLegajo,LiquidacionId,ConceptoId,CodigoConcepto,NombreConcepto,Monto,Cantidad,Precedencia,TipoConcepto")] Concepto concepto)
        {
            if (ModelState.IsValid)
            {
                _conceptoService.AddConcepto(concepto);
                await _conceptoService.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Liquidaciones", new { id = concepto.LiquidacionId });
            }
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
            return View(concepto);
        }

        // POST: Conceptos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroLegajo,LiquidacionId,ConceptoId,CodigoConcepto,NombreConcepto,Monto,Cantidad,Precedencia,TipoConcepto")] Concepto concepto)
        {
            if (id != concepto.ConceptoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _conceptoService.UpdateConcepto(concepto);
                    await _conceptoService.SaveChangesAsync();
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
                return RedirectToAction(nameof(Details), "Liquidaciones", new { id = concepto.LiquidacionId });
            }
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
