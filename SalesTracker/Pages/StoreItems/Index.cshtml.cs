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
    public class IndexModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public IndexModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        public IList<StoreItem> StoreItem { get;set; }

        public async Task OnGetAsync()
        {
            StoreItem = await _context.StoreItem
                .Include(s => s.Department).ToListAsync();
        }
    }
}
