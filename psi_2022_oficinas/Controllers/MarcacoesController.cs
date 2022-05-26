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
    public class MarcacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarcacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marcacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Marcacoes.Include(m => m.Cliente).Include(m => m.Oficina).Include(m => m.Pagamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Marcacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Marcacoes == null)
            {
                return NotFound();
            }

            var marcacoes = await _context.Marcacoes
                .Include(m => m.Cliente)
                .Include(m => m.Oficina)
                .Include(m => m.Pagamento)
                .FirstOrDefaultAsync(m => m.IdMarcacao == id);
            if (marcacoes == null)
            {
                return NotFound();
            }

            return View(marcacoes);
        }

        // GET: Marcacoes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "Apelido");
            ViewData["IdOficina"] = new SelectList(_context.Oficinas, "IdOficina", "CodigoPostal");
            ViewData["IdPagamento"] = new SelectList(_context.MetodoPagamento, "IdPagamento", "IdPagamento");
            return View();
        }

        // POST: Marcacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarcacao,DataPedido,ClassServico,EstadoServico,Descricao,Caucao,IdPagamento,IdCliente,IdOficina")] Marcacoes marcacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "Apelido", marcacoes.IdCliente);
            ViewData["IdOficina"] = new SelectList(_context.Oficinas, "IdOficina", "CodigoPostal", marcacoes.IdOficina);
            ViewData["IdPagamento"] = new SelectList(_context.MetodoPagamento, "IdPagamento", "IdPagamento", marcacoes.IdPagamento);
            return View(marcacoes);
        }

        // GET: Marcacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Marcacoes == null)
            {
                return NotFound();
            }

            var marcacoes = await _context.Marcacoes.FindAsync(id);
            if (marcacoes == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "Apelido", marcacoes.IdCliente);
            ViewData["IdOficina"] = new SelectList(_context.Oficinas, "IdOficina", "CodigoPostal", marcacoes.IdOficina);
            ViewData["IdPagamento"] = new SelectList(_context.MetodoPagamento, "IdPagamento", "IdPagamento", marcacoes.IdPagamento);
            return View(marcacoes);
        }

        // POST: Marcacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarcacao,DataPedido,ClassServico,EstadoServico,Descricao,Caucao,IdPagamento,IdCliente,IdOficina")] Marcacoes marcacoes)
        {
            if (id != marcacoes.IdMarcacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcacoesExists(marcacoes.IdMarcacao))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "Apelido", marcacoes.IdCliente);
            ViewData["IdOficina"] = new SelectList(_context.Oficinas, "IdOficina", "CodigoPostal", marcacoes.IdOficina);
            ViewData["IdPagamento"] = new SelectList(_context.MetodoPagamento, "IdPagamento", "IdPagamento", marcacoes.IdPagamento);
            return View(marcacoes);
        }

        // GET: Marcacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Marcacoes == null)
            {
                return NotFound();
            }

            var marcacoes = await _context.Marcacoes
                .Include(m => m.Cliente)
                .Include(m => m.Oficina)
                .Include(m => m.Pagamento)
                .FirstOrDefaultAsync(m => m.IdMarcacao == id);
            if (marcacoes == null)
            {
                return NotFound();
            }

            return View(marcacoes);
        }

        // POST: Marcacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Marcacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Marcacoes'  is null.");
            }
            var marcacoes = await _context.Marcacoes.FindAsync(id);
            if (marcacoes != null)
            {
                _context.Marcacoes.Remove(marcacoes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcacoesExists(int id)
        {
          return _context.Marcacoes.Any(e => e.IdMarcacao == id);
        }
    }
}
