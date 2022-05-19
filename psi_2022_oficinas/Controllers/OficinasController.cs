using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using psi_2022_oficinas.Data;
using psi_2022_oficinas.Models;

namespace psi_2022_oficinas.Controllers
{
    public class OficinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OficinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Oficinas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Oficinas.Include(o => o.Gestor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Oficinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oficinas == null)
            {
                return NotFound();
            }

            var oficinas = await _context.Oficinas
                .Include(o => o.Gestor)
                .FirstOrDefaultAsync(m => m.IdOficina == id);
            if (oficinas == null)
            {
                return NotFound();
            }

            return View(oficinas);
        }

        // GET: Oficinas/Create
        public IActionResult Create()
        {
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Email");
            return View();
        }

        // POST: Oficinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOficina,Nome,Imagem,Morada,Localidade,CodigoPostal,NumTelemovel,IdGestor")] Oficinas oficinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oficinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Email", oficinas.IdGestor);
            return View(oficinas);
        }

        // GET: Oficinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oficinas == null)
            {
                return NotFound();
            }

            var oficinas = await _context.Oficinas.FindAsync(id);
            if (oficinas == null)
            {
                return NotFound();
            }
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Email", oficinas.IdGestor);
            return View(oficinas);
        }

        // POST: Oficinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOficina,Nome,Imagem,Morada,Localidade,CodigoPostal,NumTelemovel,IdGestor")] Oficinas oficinas)
        {
            if (id != oficinas.IdOficina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oficinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OficinasExists(oficinas.IdOficina))
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
            ViewData["IdGestor"] = new SelectList(_context.Gestores, "GestorID", "Email", oficinas.IdGestor);
            return View(oficinas);
        }

        // GET: Oficinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oficinas == null)
            {
                return NotFound();
            }

            var oficinas = await _context.Oficinas
                .Include(o => o.Gestor)
                .FirstOrDefaultAsync(m => m.IdOficina == id);
            if (oficinas == null)
            {
                return NotFound();
            }

            return View(oficinas);
        }

        // POST: Oficinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oficinas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Oficinas'  is null.");
            }
            var oficinas = await _context.Oficinas.FindAsync(id);
            if (oficinas != null)
            {
                _context.Oficinas.Remove(oficinas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OficinasExists(int id)
        {
          return _context.Oficinas.Any(e => e.IdOficina == id);
        }
    }
}
