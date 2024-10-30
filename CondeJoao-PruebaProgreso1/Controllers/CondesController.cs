using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CondeJoao_PruebaProgreso1.Data;
using CondeJoao_PruebaProgreso1.Models;

namespace CondeJoao_PruebaProgreso1.Controllers
{
    public class CondesController : Controller
    {
        private readonly CondeJoao_PruebaProgreso1Context _context;

        public CondesController(CondeJoao_PruebaProgreso1Context context)
        {
            _context = context;
        }

        // GET: Condes
        public async Task<IActionResult> Index()
        {
            var condeJoao_PruebaProgreso1Context = _context.Conde.Include(c => c.Celular);
            return View(await condeJoao_PruebaProgreso1Context.ToListAsync());
        }

        // GET: Condes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conde = await _context.Conde
                .Include(c => c.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conde == null)
            {
                return NotFound();
            }

            return View(conde);
        }

        // GET: Condes/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo");
            return View();
        }

        // POST: Condes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Presupuesto,TieneTrabajo,FechaNacimiento,IdCelular")] Conde conde)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", conde.IdCelular);
            return View(conde);
        }

        // GET: Condes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conde = await _context.Conde.FindAsync(id);
            if (conde == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", conde.IdCelular);
            return View(conde);
        }

        // POST: Condes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Presupuesto,TieneTrabajo,FechaNacimiento,IdCelular")] Conde conde)
        {
            if (id != conde.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondeExists(conde.Id))
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
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Modelo", conde.IdCelular);
            return View(conde);
        }

        // GET: Condes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conde = await _context.Conde
                .Include(c => c.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conde == null)
            {
                return NotFound();
            }

            return View(conde);
        }

        // POST: Condes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conde = await _context.Conde.FindAsync(id);
            if (conde != null)
            {
                _context.Conde.Remove(conde);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondeExists(int id)
        {
            return _context.Conde.Any(e => e.Id == id);
        }
    }
}
