using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages.Sales
{
    public class IndexModel : PageModel
    {
        private readonly SalesTracker.Models.SalesTrackerContext _context;

        public IndexModel(SalesTracker.Models.SalesTrackerContext context)
        {
            _context = context;
        }

        public IList<Sale> Sale { get;set; }

        public async Task OnGetAsync()
        {
            Sale = await _context.Sale
                .Include(s => s.SalesPerson)
                .Include(s => s.StoreItem).ToListAsync();
        }
    }
}
