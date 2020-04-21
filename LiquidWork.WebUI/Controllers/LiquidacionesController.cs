using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidWork.WebUI.Controllers
{
    public class LiquidacionesController : Controller
    {
        private readonly DataContext _context;

        public LiquidacionesController(DataContext context)
        {
            _context = context;
        }

        // GET: Liquidaciones
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Liquidaciones;
            return View(await dataContext.ToListAsync());
        }

        // GET: Liquidaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquidacion = await _context.Liquidaciones
                .FirstOrDefaultAsync(m => m.LiquidacionId == id);
            if (liquidacion == null)
            {
                return NotFound();
            }

            return View(liquidacion);
        }

        // GET: Liquidaciones/Create
        public IActionResult Create()
        {
            ViewData["NumeroLegajo"] = new SelectList(_context.Legajos, "NumeroLegajo", "NumeroLegajo");
            return View();
        }

        // POST: Liquidaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LiquidacionId,Periodo,NumeroLegajo")] Liquidacion liquidacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liquidacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Legajos", new { id = liquidacion.NumeroLegajo });
            }
            ViewData["NumeroLegajo"] = new SelectList(_context.Legajos, "NumeroLegajo", "NumeroLegajo", liquidacion.NumeroLegajo);
            return View(liquidacion);
        }

        // GET: Liquidaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquidacion = await _context.Liquidaciones
                .FirstOrDefaultAsync(m => m.LiquidacionId == id);
            if (liquidacion == null)
            {
                return NotFound();
            }

            return View(liquidacion);
        }

        // POST: Liquidaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liquidacion = await _context.Liquidaciones.FindAsync(id);
            _context.Liquidaciones.Remove(liquidacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiquidacionExists(int id)
        {
            return _context.Liquidaciones.Any(e => e.LiquidacionId == id);
        }
    }
}
