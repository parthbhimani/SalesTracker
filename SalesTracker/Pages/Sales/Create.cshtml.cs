using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesTracker.Models;

namespace SalesTracker.Pages.Sales
{
    public class CreateModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public CreateModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sale Sale { get; set; }

        public IActionResult OnGet(int? itemId, int? SalesPersonId)
        {
        ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "Id", "FirstName");
        ViewData["StoreItemId"] = new SelectList(_context.Set<StoreItem>(), "Id", "ItemName");

            if (itemId != null)
            {
                Sale = new Sale();
                Sale.StoreItemId = itemId.GetValueOrDefault();
            } else if (SalesPersonId != null)
            {
                Sale = new Sale();
                Sale.SalesPersonId = SalesPersonId.GetValueOrDefault();
            }
       
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

            _context.Sale.Add(Sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}