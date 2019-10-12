using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages.SalesPeople
{
    public class EditModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public EditModel(SalesTracker.Models.SalesTrackerContext context)
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

            _context.Attach(SalesPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesPersonExists(SalesPerson.Id))
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

        private bool SalesPersonExists(int id)
        {
            return _context.SalesPerson.Any(e => e.Id == id);
        }
    }
}
