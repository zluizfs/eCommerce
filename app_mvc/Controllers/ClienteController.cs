using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCommerce.Models.DataContext;
using eCommerce.Models.Table;
using Microsoft.AspNetCore.Authorization;
using eCommerceDAL;

namespace eCommerce.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly eCommerceContext _context;
        private readonly ClienteDAL clienteDAL;
        public ClienteController(eCommerceContext context)
        {
            _context = context;
            clienteDAL = new ClienteDAL(context);
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            var clientes = await clienteDAL.Listar();

            return View(clientes);
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await clienteDAL.ObterPessoaVinculada((int) id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "IdPessoa", "Nome");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPessoa, IsPreferencial")] Cliente cliente)
        {
            if (ModelState.IsValid && cliente.IdPessoa == 0)
            {
                var inserir = await clienteDAL.Inserir(cliente);

                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "IdPessoa", "Nome", cliente.IdPessoa);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await clienteDAL.ObterPessoaFisicaOuJuridicaVinculada((int) id);

            if (cliente == null)
            {
                return NotFound();
            }
            // ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "IdPessoa", "Nome", cliente.IdPessoa);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPessoa, IsPreferencial, IdPessoaNavigation")] Cliente cliente)
        {
            if (id != cliente.IdPessoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var resultAtualizar = await clienteDAL.Atualizar(cliente);
                
                if(!resultAtualizar)
                {
                    return NotFound();
                }
                
                return RedirectToAction(nameof(Index));
            }

            // ViewData["IdPessoa"] = new SelectList(_context.Pessoas, "IdPessoa", "Nome", cliente.IdPessoa);

            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await clienteDAL.ObterPessoaVinculada((int) id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await clienteDAL.ExcluirPorId(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
