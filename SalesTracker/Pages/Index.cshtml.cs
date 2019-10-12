using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages
{
    public class IndexModel : PageModel
    {

        private SalesTrackerContext _context;
        private object sls;

        public ICollection<SalesPerson> SalesPeople { get; set; }

        public IndexModel(SalesTrackerContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            SalesPeople = _context.SalesPerson.Include(slsp => slsp.AwardNotice)
                .Include(slsp => slsp.Sales)
                .ThenInclude(sle => sle.StoreItem).ToArray();
        }

        
    }
}
