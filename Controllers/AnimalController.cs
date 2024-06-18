using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoProcura.Models;

namespace ProjetoProcura.Controllers
{
    public class AnimalController : Controller
    {
        private readonly Contexto _context;

        public AnimalController(Contexto context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Animal.Include(a => a.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animal == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalId,NomeAnimal,AnimalRaca,AnimalTipo,AnimalCor,AnimalSexo,AnimalObservacao,AnimalFoto,AnimalDtDesaparecimento,AnimalDtEncontro,AnimalStatus,UsuarioId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", animal.UsuarioId);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animal == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", animal.UsuarioId);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalId,NomeAnimal,AnimalRaca,AnimalTipo,AnimalCor,AnimalSexo,AnimalObservacao,AnimalFoto,AnimalDtDesaparecimento,AnimalDtEncontro,AnimalStatus,UsuarioId")] Animal animal)
        {
            if (id != animal.AnimalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.AnimalId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", animal.UsuarioId);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animal == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animal == null)
            {
                return Problem("Entity set 'Contexto.Animal'  is null.");
            }
            var animal = await _context.Animal.FindAsync(id);
            if (animal != null)
            {
                _context.Animal.Remove(animal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
          return (_context.Animal?.Any(e => e.AnimalId == id)).GetValueOrDefault();
        }
    }
}
