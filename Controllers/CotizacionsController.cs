using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEventosSonart.Data;
using SistemaEventosSonart.Models;

namespace SistemaEventosSonart.Controllers
{
    public class CotizacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CotizacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cotizacions
        public async Task<IActionResult> Index()
        {
            var cotizaciones = _context.Cotizaciones
                .Include(c => c.SolicitudEvento)
                .Include(c => c.PaqueteServicio);

            return View(await cotizaciones.ToListAsync());
        }

        // GET: Cotizacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones
                .Include(c => c.SolicitudEvento)
                .Include(c => c.PaqueteServicio)
                .FirstOrDefaultAsync(m => m.CotizacionId == id);

            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // GET: Cotizacions/Create
        public IActionResult Create()
        {
            ViewData["SolicitudEventoId"] = new SelectList(_context.SolicitudesEvento, "SolicitudEventoId", "TipoEvento");
            ViewData["PaqueteServicioId"] = new SelectList(_context.PaquetesServicio, "PaqueteServicioId", "NombrePaquete");
            return View();
        }

        // POST: Cotizacions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CotizacionId,SolicitudEventoId,PaqueteServicioId,FechaCotizacion,EstadoCotizacion")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SolicitudEventoId"] = new SelectList(_context.SolicitudesEvento, "SolicitudEventoId", "TipoEvento", cotizacion.SolicitudEventoId);
            ViewData["PaqueteServicioId"] = new SelectList(_context.PaquetesServicio, "PaqueteServicioId", "NombrePaquete", cotizacion.PaqueteServicioId);
            return View(cotizacion);
        }

        // GET: Cotizacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones.FindAsync(id);

            if (cotizacion == null)
            {
                return NotFound();
            }

            ViewData["SolicitudEventoId"] = new SelectList(_context.SolicitudesEvento, "SolicitudEventoId", "TipoEvento", cotizacion.SolicitudEventoId);
            ViewData["PaqueteServicioId"] = new SelectList(_context.PaquetesServicio, "PaqueteServicioId", "NombrePaquete", cotizacion.PaqueteServicioId);
            return View(cotizacion);
        }

        // POST: Cotizacions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CotizacionId,SolicitudEventoId,PaqueteServicioId,FechaCotizacion,EstadoCotizacion")] Cotizacion cotizacion)
        {
            if (id != cotizacion.CotizacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.CotizacionId))
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

            ViewData["SolicitudEventoId"] = new SelectList(_context.SolicitudesEvento, "SolicitudEventoId", "TipoEvento", cotizacion.SolicitudEventoId);
            ViewData["PaqueteServicioId"] = new SelectList(_context.PaquetesServicio, "PaqueteServicioId", "NombrePaquete", cotizacion.PaqueteServicioId);
            return View(cotizacion);
        }

        // GET: Cotizacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones
                .Include(c => c.SolicitudEvento)
                .Include(c => c.PaqueteServicio)
                .FirstOrDefaultAsync(m => m.CotizacionId == id);

            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: Cotizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizacion = await _context.Cotizaciones.FindAsync(id);

            if (cotizacion != null)
            {
                _context.Cotizaciones.Remove(cotizacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionExists(int id)
        {
            return _context.Cotizaciones.Any(e => e.CotizacionId == id);
        }
    }
}