using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEventosSonart.Data;
using SistemaEventosSonart.Models;

namespace SistemaEventosSonart.Controllers
{
    public class SolicitudEventoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudEventoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SolicitudEventoes
        public async Task<IActionResult> Index()
        {
            var solicitudes = _context.SolicitudesEvento.Include(s => s.Cliente);
            return View(await solicitudes.ToListAsync());
        }

        // GET: SolicitudEventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudEvento = await _context.SolicitudesEvento
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.SolicitudEventoId == id);

            if (solicitudEvento == null)
            {
                return NotFound();
            }

            return View(solicitudEvento);
        }

        // GET: SolicitudEventoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre");
            return View();
        }

        // POST: SolicitudEventoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SolicitudEventoId,ClienteId,TipoEvento,FechaEvento,EstadoSolicitud")] SolicitudEvento solicitudEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitudEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", solicitudEvento.ClienteId);
            return View(solicitudEvento);
        }

        // GET: SolicitudEventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudEvento = await _context.SolicitudesEvento.FindAsync(id);

            if (solicitudEvento == null)
            {
                return NotFound();
            }

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", solicitudEvento.ClienteId);
            return View(solicitudEvento);
        }

        // POST: SolicitudEventoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SolicitudEventoId,ClienteId,TipoEvento,FechaEvento,EstadoSolicitud")] SolicitudEvento solicitudEvento)
        {
            if (id != solicitudEvento.SolicitudEventoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitudEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudEventoExists(solicitudEvento.SolicitudEventoId))
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

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", solicitudEvento.ClienteId);
            return View(solicitudEvento);
        }

        // GET: SolicitudEventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudEvento = await _context.SolicitudesEvento
                .Include(s => s.Cliente)
                .FirstOrDefaultAsync(m => m.SolicitudEventoId == id);

            if (solicitudEvento == null)
            {
                return NotFound();
            }

            return View(solicitudEvento);
        }

        // POST: SolicitudEventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitudEvento = await _context.SolicitudesEvento.FindAsync(id);

            if (solicitudEvento != null)
            {
                _context.SolicitudesEvento.Remove(solicitudEvento);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudEventoExists(int id)
        {
            return _context.SolicitudesEvento.Any(e => e.SolicitudEventoId == id);
        }
    }
}