using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trivia_api.Models;
using trivia_api.ORM;

namespace trivia_api.Controllers
{
    public class LobbiesController : Controller
    {
        private readonly TreeviaDbContext _context;

        public LobbiesController(TreeviaDbContext context)
        {
            _context = context;
        }

        // GET: Lobbies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lobby.ToListAsync());
        }

        // GET: Lobbies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lobby = await _context.Lobby
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lobby == null)
            {
                return NotFound();
            }

            return View(lobby);
        }

        // GET: Lobbies/Create
        public IActionResult Create()
        {
            Lobby newModel = new Lobby();
            return View(newModel);
        }

        // POST: Lobbies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Owner,Title,Members,MembersCounter,Type,LobbyNumber,Published,Updated")] Lobby lobby)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lobby);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lobby);
        }

        // GET: Lobbies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lobby = await _context.Lobby.FindAsync(id);
            if (lobby == null)
            {
                return NotFound();
            }
            return View(lobby);
        }

        // POST: Lobbies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Owner,Title,Members,MembersCounter,Type,LobbyNumber,Published,Updated")] Lobby lobby)
        {
            if (id != lobby.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lobby);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LobbyExists(lobby.Id))
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
            return View(lobby);
        }

        // GET: Lobbies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lobby = await _context.Lobby
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lobby == null)
            {
                return NotFound();
            }

            return View(lobby);
        }

        // POST: Lobbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lobby = await _context.Lobby.FindAsync(id);
            _context.Lobby.Remove(lobby);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LobbyExists(string id)
        {
            return _context.Lobby.Any(e => e.Id == id);
        }
    }
}
