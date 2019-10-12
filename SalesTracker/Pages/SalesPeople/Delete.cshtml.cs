using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages.SalesPeople
{
    public class DeleteModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public DeleteModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesPerson SalesPerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesPerson = await _context.SalesPerson
                .Include(s => s.Department).FirstOrDefaultAsync(m => m.Id == id);

            if (SalesPerson == null)
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

            SalesPerson = await _context.SalesPerson.FindAsync(id);

            if (SalesPerson != null)
            {
                _context.SalesPerson.Remove(SalesPerson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
