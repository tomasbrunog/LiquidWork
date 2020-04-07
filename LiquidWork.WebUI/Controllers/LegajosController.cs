using LiquidWork.Core.Model;
using LiquidWork.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidWork.WebUI.Controllers
{
    public class LegajosController : Controller
    {
        private readonly DataContext _context;

        public LegajosController(DataContext context)
        {
            _context = context;
        }

        // GET: Legajos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Legajos.ToListAsync());
        }

        // GET: Legajos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legajo = await _context.Legajos
                .Include(l => l.ConceptosFijos)
                .Include(l => l.Liquidaciones)
                .FirstOrDefaultAsync(m => m.NumeroLegajo == id);
            if (legajo == null)
            {
                return NotFound();
            }

            return View(legajo);
        }

        // GET: Legajos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Legajos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroLegajo,Nombre,Apellido,CUIL,Categoria,FechaIngreso")] Legajo legajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legajo);
        }

        // GET: Legajos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legajo = await _context.Legajos.FindAsync(id);
            if (legajo == null)
            {
                return NotFound();
            }
            return View(legajo);
        }

        // POST: Legajos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroLegajo,Nombre,Apellido,CUIL,Categoria,FechaIngreso")] Legajo legajo)
        {
            if (id != legajo.NumeroLegajo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegajoExists(legajo.NumeroLegajo))
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
            return View(legajo);
        }

        // GET: Legajos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legajo = await _context.Legajos
                .FirstOrDefaultAsync(l => l.NumeroLegajo == id);
            if (legajo == null)
            {
                return NotFound();
            }

            return View(legajo);
        }

        // POST: Legajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legajo = await _context.Legajos.FindAsync(id);
            _context.Legajos.Remove(legajo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegajoExists(int id)
        {
            return _context.Legajos.Any(l => l.NumeroLegajo == id);
        }
    }
}
