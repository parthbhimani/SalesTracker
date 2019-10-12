using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages.AwardsNotices
{
    public class DetailsModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public DetailsModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
