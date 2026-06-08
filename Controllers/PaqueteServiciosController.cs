using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEventosSonart.Data;
using SistemaEventosSonart.Models;

namespace SistemaEventosSonart.Controllers
{
    public class PaqueteServiciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaqueteServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaqueteServicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaquetesServicio.ToListAsync());
        }

        // GET: PaqueteServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paqueteServicio = await _context.PaquetesServicio
                .FirstOrDefaultAsync(m => m.PaqueteServicioId == id);

            if (paqueteServicio == null)
            {
                return NotFound();
            }

            return View(paqueteServicio);
        }

        // GET: PaqueteServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaqueteServicios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaqueteServicioId,NombrePaquete,CapacidadPersonas,Descripcion,PrecioBase")] PaqueteServicio paqueteServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paqueteServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paqueteServicio);
        }

        // GET: PaqueteServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paqueteServicio = await _context.PaquetesServicio.FindAsync(id);

            if (paqueteServicio == null)
            {
                return NotFound();
            }

            return View(paqueteServicio);
        }

        // POST: PaqueteServicios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaqueteServicioId,NombrePaquete,CapacidadPersonas,Descripcion,PrecioBase")] PaqueteServicio paqueteServicio)
        {
            if (id != paqueteServicio.PaqueteServicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paqueteServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaqueteServicioExists(paqueteServicio.PaqueteServicioId))
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

            return View(paqueteServicio);
        }

        // GET: PaqueteServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paqueteServicio = await _context.PaquetesServicio
                .FirstOrDefaultAsync(m => m.PaqueteServicioId == id);

            if (paqueteServicio == null)
            {
                return NotFound();
            }

            return View(paqueteServicio);
        }

        // POST: PaqueteServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paqueteServicio = await _context.PaquetesServicio.FindAsync(id);

            if (paqueteServicio != null)
            {
                _context.PaquetesServicio.Remove(paqueteServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaqueteServicioExists(int id)
        {
            return _context.PaquetesServicio.Any(e => e.PaqueteServicioId == id);
        }
    }
}