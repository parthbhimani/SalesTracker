using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages.StoreItems
{
    public class EditModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public EditModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StoreItem StoreItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoreItem = await _context.StoreItem
                .Include(s => s.Department).FirstOrDefaultAsync(m => m.Id == id);

            if (StoreItem == null)
            {
                return NotFound();
            }
           ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName");
                return Page();
            }

            _context.Attach(StoreItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreItemExists(StoreItem.Id))
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

        private bool StoreItemExists(int id)
        {
            return _context.StoreItem.Any(e => e.Id == id);
        }
    }
}
