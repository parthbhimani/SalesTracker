using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages.StoreItems
{
    public class DeleteModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public DeleteModel(SalesTracker.Models.SalesTrackerContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StoreItem = await _context.StoreItem.FindAsync(id);

            if (StoreItem != null)
            {
                _context.StoreItem.Remove(StoreItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
