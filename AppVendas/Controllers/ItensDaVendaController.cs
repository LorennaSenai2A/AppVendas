﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppVendas.Data;
using AppVendas.Models;

namespace AppVendas.Controllers
{
    public class ItensDaVendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItensDaVendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItensDaVenda
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItensDaVenda.Include(i => i.Produto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItensDaVenda/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDaVenda = await _context.ItensDaVenda
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.ItemDaVendaId == id);
            if (itemDaVenda == null)
            {
                return NotFound();
            }

            return View(itemDaVenda);
        }

        // GET: ItensDaVenda/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId");
            return View();
        }

        // POST: ItensDaVenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemDaVendaId,ProdutoId,QtdadeVendida,ValorTotalDoItem")] ItemDaVenda itemDaVenda)
        {
            if (ModelState.IsValid)
            {
                itemDaVenda.ItemDaVendaId = Guid.NewGuid();
                _context.Add(itemDaVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemDaVenda.ProdutoId);
            return View(itemDaVenda);
        }

        // GET: ItensDaVenda/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDaVenda = await _context.ItensDaVenda.FindAsync(id);
            if (itemDaVenda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemDaVenda.ProdutoId);
            return View(itemDaVenda);
        }

        // POST: ItensDaVenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItemDaVendaId,ProdutoId,QtdadeVendida,ValorTotalDoItem")] ItemDaVenda itemDaVenda)
        {
            if (id != itemDaVenda.ItemDaVendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemDaVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemDaVendaExists(itemDaVenda.ItemDaVendaId))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoId", itemDaVenda.ProdutoId);
            return View(itemDaVenda);
        }

        // GET: ItensDaVenda/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDaVenda = await _context.ItensDaVenda
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.ItemDaVendaId == id);
            if (itemDaVenda == null)
            {
                return NotFound();
            }

            return View(itemDaVenda);
        }

        // POST: ItensDaVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var itemDaVenda = await _context.ItensDaVenda.FindAsync(id);
            if (itemDaVenda != null)
            {
                _context.ItensDaVenda.Remove(itemDaVenda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemDaVendaExists(Guid id)
        {
            return _context.ItensDaVenda.Any(e => e.ItemDaVendaId == id);
        }
    }
}
