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
    public class SearchStoreItemsModel : PageModel
    {

        SalesTrackerContext _context;

        public SearchStoreItemsModel(SalesTrackerContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            SearchCompleted = false;
        }


        [BindProperty]
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<StoreItem> SearchResults { get; set; }

        public void OnPost()
        {
            if (string.IsNullOrWhiteSpace(Search))
            {
                return;
            }

            SearchResults = _context.StoreItem.Include(x => x.Department)
                                    .Where(x => x.ItemName.ToLower().Contains(Search.ToLower()))
                                    .ToList();

            SearchCompleted = true;
        }
    }
}