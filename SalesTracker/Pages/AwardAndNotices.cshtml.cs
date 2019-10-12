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
    public class AwardAndNoticesModel : PageModel
    {
        private SalesTrackerContext _context;

        public ICollection<AwardNotice> AwardsAndNotices { get; set; }
        public AwardAndNoticesModel(SalesTrackerContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            AwardsAndNotices = _context.AwardNotice.Include(awno => awno.SalesPerson).ToArray();
        }
    }
}