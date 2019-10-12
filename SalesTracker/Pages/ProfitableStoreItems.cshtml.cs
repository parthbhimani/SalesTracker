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
    public class StoreItemsModel : PageModel
    {
        private SalesTrackerContext _context;

        public ICollection<StoreItem> items { get; set; }
        public StoreItemsModel(SalesTrackerContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            items = _context.StoreItem.Include(itm => itm.Department).ToArray();

        }
    }
}