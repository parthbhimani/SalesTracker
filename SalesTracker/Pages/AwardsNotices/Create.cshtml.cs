using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesTracker.Models;

namespace SalesTracker.Pages.AwardsNotices
{
    public class CreateModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public CreateModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public AwardNotice AwardNotice { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "Id", "FirstName");
                return Page();
            }

            _context.AwardNotice.Add(AwardNotice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}