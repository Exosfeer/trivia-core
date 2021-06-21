using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trivia_api.Models;
using trivia_api.ORM;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace trivia_api.Controllers
{
    public class AccountsController : Controller
    {
        private readonly TreeviaDbContext _context;

        public AccountsController(TreeviaDbContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Account.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/DetailsJson/5
        public async Task<String> DetailsJson(string id)
        {
            if (id == null)
            {
                return "not found";
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return "not found";
            }

            return JsonConvert.SerializeObject(account);
        }

        // GET: Accounts/Json/5
        public async Task<String> Json(string id)
        {
            if (id == null)
            {
                return "not found";
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return "not found";
            }

            return JsonConvert.SerializeObject(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            Account newModel = new Account();
            return View(newModel);
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Username,Password,LastLogin,CreatedAt")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ProducesResponseType(typeof(Account), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateJson([FromBody] Account postAccount)
        {

            if (postAccount != null)
            {
                if (ModelState.IsValid)
                {
                    EntityEntry<Account> accountEntityEntry = _context.Add(postAccount);
                    await _context.SaveChangesAsync();
                    return Ok(accountEntityEntry.Entity);
                }
            }

            return BadRequest();
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,Username,Password,LastLogin,CreatedAt")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ProducesResponseType(typeof(Account), StatusCodes.Status200OK)]
        public async Task<IActionResult> EditJson([FromBody] Account postAccount)
        {
            if (postAccount != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        EntityEntry<Account> accountEntityEntry = _context.Update(postAccount);
                        await _context.SaveChangesAsync();

                        return Ok(accountEntityEntry.Entity);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AccountExists(postAccount.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            return NotFound();
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var account = await _context.Account.FindAsync(id);
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Accounts/Delete/5
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteJsonConfirmed([FromBody] Account postAccount)
        {
            if (postAccount != null)
            {
                var account = await _context.Account.FindAsync(postAccount.Id);
                if (account != null)
                {
                    _context.Account.Remove(account);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            return NotFound();
        }

        private bool AccountExists(string id)
        {
            return _context.Account.Any(e => e.Id == id);
        }
    }
}
