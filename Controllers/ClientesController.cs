using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnectFlow.Data;
using ConnectFlow.Models;

namespace ConnectFlow.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Cnpj,RazaoSocial,NomeFantasia,ResponsavelTecnico,EmailCorporativo,Telefone")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Configuracao", new { id = cliente.IdCliente });
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Cnpj,RazaoSocial,NomeFantasia,ResponsavelTecnico,EmailCorporativo,Telefone")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    

         public IActionResult Configuracao(int id)
        {
            var config = new ConnectFlow.Models.Configuracao { IdCliente = id };
            return View(config);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Configuracao(int id, string volumeDados)
        {
            // Esse código é o que o botão "Próximo" da tela de configuração chama.
            // Ele simplesmente pega o ID e te joga para a próxima tela: Acessibilidade.
            return RedirectToAction("Acessibilidade", new { id = id });
        }

        // 1. Método que ABRE a tela (Caminho: /Clientes/Acessibilidade/ID)
        [HttpGet]
        public IActionResult Acessibilidade(int id)
        {
            // Isso garante que o C# saiba qual cliente estamos configurando
            var config = new ConnectFlow.Models.Configuracao { IdCliente = id };

            // Forçamos o retorno da View específica
            return View("Acessibilidade", config);
        }

        // 2. Método que PROCESSA o botão Próximo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Acessibilidade(int id, bool suporteLibras, bool notificacoesEmail)
        {
            // Aqui você salvaria as preferências no banco se quisesse.
            // Por enquanto, vamos apenas navegar para a tela final:
            return RedirectToAction("Sucesso");
        }

        // Crie este novo método para abrir a tela de sucesso:
        public IActionResult Sucesso()
        {
            return View();
        }

    }

}
