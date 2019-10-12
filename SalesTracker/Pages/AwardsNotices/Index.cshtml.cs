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
    public class IndexModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public IndexModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        public IList<AwardNotice> AwardNotice { get;set; }

        public async Task OnGetAsync()
        {
            AwardNotice = await _context.AwardNotice
                .Include(a => a.SalesPerson).ToListAsync();
        }
    }
}
