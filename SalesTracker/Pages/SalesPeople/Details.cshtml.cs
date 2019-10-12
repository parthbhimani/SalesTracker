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
    public class DetailsModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public DetailsModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        public SalesPerson SalesPerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesPerson = await _context.SalesPerson
                .Include(s => s.Department).Include(s => s.AwardNotice).Include(s => s.Sales).ThenInclude(sa => sa.StoreItem).FirstOrDefaultAsync(m => m.Id == id);

            if (SalesPerson == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
