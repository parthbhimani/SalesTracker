using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages.AwardsNotices
{
    public class EditModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public EditModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AwardNotice AwardNotice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AwardNotice = await _context.AwardNotice
                .Include(a => a.SalesPerson).FirstOrDefaultAsync(m => m.Id == id);

            if (AwardNotice == null)
            {
                return NotFound();
            }
           ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "Id", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "Id", "FirstName");
                return Page();
            }

            _context.Attach(AwardNotice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwardNoticeExists(AwardNotice.Id))
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

        private bool AwardNoticeExists(int id)
        {
            return _context.AwardNotice.Any(e => e.Id == id);
        }
    }
}
