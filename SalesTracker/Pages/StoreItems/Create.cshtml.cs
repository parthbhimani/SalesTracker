using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesTracker.Models;

namespace SalesTracker.Pages.StoreItems
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
        ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName");
            return Page();
        }

        [BindProperty]
        public StoreItem StoreItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName");
                return Page();
            }

            _context.StoreItem.Add(StoreItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}