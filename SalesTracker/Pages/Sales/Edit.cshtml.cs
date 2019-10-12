using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages.Sales
{
    public class EditModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public EditModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sale Sale { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale = await _context.Sale
                .Include(s => s.SalesPerson)
                .Include(s => s.StoreItem).FirstOrDefaultAsync(m => m.Id == id);

            if (Sale == null)
            {
                return NotFound();
            }
           ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "Id", "FirstName");
           ViewData["StoreItemId"] = new SelectList(_context.Set<StoreItem>(), "Id", "ItemName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "Id", "FirstName");
                ViewData["StoreItemId"] = new SelectList(_context.Set<StoreItem>(), "Id", "ItemName");
                return Page();
            }

            _context.Attach(Sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(Sale.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SaleExists(int id)
        {
            return _context.Sale.Any(e => e.Id == id);
        }
    }
}
