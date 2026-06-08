using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventosSonart.Data;
using SistemaEventosSonart.Models;

namespace SistemaEventosSonart.Controllers
{
    public class ServicioAdicionalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicioAdicionalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicioAdicionals
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiciosAdicionales.ToListAsync());
        }

        // GET: ServicioAdicionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioAdicional = await _context.ServiciosAdicionales
                .FirstOrDefaultAsync(m => m.ServicioAdicionalId == id);

            if (servicioAdicional == null)
            {
                return NotFound();
            }

            return View(servicioAdicional);
        }

        // GET: ServicioAdicionals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicioAdicionals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicioAdicionalId,NombreServicio,Categoria,Descripcion,PrecioReferencial")] ServicioAdicional servicioAdicional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioAdicional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(servicioAdicional);
        }

        // GET: ServicioAdicionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioAdicional = await _context.ServiciosAdicionales.FindAsync(id);

            if (servicioAdicional == null)
            {
                return NotFound();
            }

            return View(servicioAdicional);
        }

        // POST: ServicioAdicionals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicioAdicionalId,NombreServicio,Categoria,Descripcion,PrecioReferencial")] ServicioAdicional servicioAdicional)
        {
            if (id != servicioAdicional.ServicioAdicionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioAdicional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioAdicionalExists(servicioAdicional.ServicioAdicionalId))
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

            return View(servicioAdicional);
        }

        // GET: ServicioAdicionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioAdicional = await _context.ServiciosAdicionales
                .FirstOrDefaultAsync(m => m.ServicioAdicionalId == id);

            if (servicioAdicional == null)
            {
                return NotFound();
            }

            return View(servicioAdicional);
        }

        // POST: ServicioAdicionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioAdicional = await _context.ServiciosAdicionales.FindAsync(id);

            if (servicioAdicional != null)
            {
                _context.ServiciosAdicionales.Remove(servicioAdicional);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ServicioAdicionalExists(int id)
        {
            return _context.ServiciosAdicionales.Any(e => e.ServicioAdicionalId == id);
        }
    }
}