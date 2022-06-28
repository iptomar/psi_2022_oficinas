using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        /// <summary>
        /// esta variável recolhe os dados da pessoa q se autenticou
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        public MarcacoesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Marcacoes
        public async Task<IActionResult> Index()
        {
            string idDaPessoaAutenticada = _userManager.GetUserId(User);

            var marcacoes = await (from v in _context.Marcacoes.Include(v => v.Cliente).Include(v => v.Pagamento).Include(v => v.Oficina)
                                   join c in _context.Clientes on v.IdCliente equals c.IdClientes
                                   join u in _context.Users on c.Email equals u.Email
                                   where u.Id == idDaPessoaAutenticada
                                   select v)
                                  .ToListAsync();

            return View(marcacoes);
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "IdClientes");
            ViewData["IdOficina"] = new SelectList(_context.Oficinas, "IdOficina", "Nome");
            ViewData["IdPagamento"] = new SelectList(_context.MetodoPagamento, "IdPagamento", "TipoPagamento");
            return View();
        }

        // POST: Marcacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarcacao,DataPedido,ClassServico,EstadoServico,Descricao,Caucao,IdPagamento,IdOficina")] Marcacoes marcacoes)
        {
            if (ModelState.IsValid)
            {
                // obter os dados da pessoa autenticada
                Clientes cliente = _context.Clientes.Where(c => c.UserName == _userManager.GetUserId(User)).FirstOrDefault();
                // adicionar o cliente ao veículo
                marcacoes.Cliente = cliente;

                _context.Add(marcacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOficina"] = new SelectList(_context.Oficinas, "IdOficina", "CodigoPostal", marcacoes.Oficina);
            ViewData["IdPagamento"] = new SelectList(_context.MetodoPagamento, "IdPagamento", "IdPagamento", marcacoes.Pagamento);
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
            ViewData["IdOficina"] = new SelectList(_context.Oficinas, "IdOficina", "CodigoPostal", marcacoes.Oficina);
            ViewData["IdPagamento"] = new SelectList(_context.MetodoPagamento, "IdPagamento", "IdPagamento", marcacoes.Pagamento);
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
            ViewData["IdOficina"] = new SelectList(_context.Oficinas, "IdOficina", "CodigoPostal", marcacoes.Oficina);
            ViewData["IdPagamento"] = new SelectList(_context.MetodoPagamento, "IdPagamento", "IdPagamento", marcacoes.Pagamento);
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
