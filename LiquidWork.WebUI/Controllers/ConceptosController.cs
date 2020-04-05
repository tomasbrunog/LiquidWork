using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
            TempData["numeroLegajo"] = numeroLegajo;
            TempData["liquidacionId"] = numeroLegajo;
            return View();
        }

        // POST: Conceptos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroLegajo,ConceptoId,NombreConcepto,Monto,Cantidad,Precedencia,TipoConcepto")] Concepto concepto, int? numeroLegajo, int? liquidacionId)
        {
            if (ModelState.IsValid)
            {

                if (numeroLegajo != null)
                {
                    concepto.Legajo = _context.Legajos
                .FirstOrDefault(l => l.NumeroLegajo == numeroLegajo); 
                }
                if (liquidacionId != null)
                {
                    concepto.Liquidacion = _context.Liquidaciones
                .FirstOrDefault(l => l.LiquidacionId == liquidacionId); 
                }
                _context.Add(concepto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("ConceptoId,NombreConcepto,Monto,Cantidad,Precedencia,TipoConcepto")] Concepto concepto)
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
