using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalesTracker.Models;
using SalesTracker.Models.Forms;

namespace SalesTracker.Pages.Forms
{
    public class FireSalesPersonFormModel : PageModel
    {
     
        private readonly SalesTrackerContext _context;
        public FireSalesPersonFormModel(SalesTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FireSPForm FireSPForm { get; set; }
        
        public SalesPerson SalesPerson { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesPerson = _context.SalesPerson.Find(id);

            if (SalesPerson == null)
            {
                return NotFound();
            }

            FireSPForm = new FireSPForm();
            FireSPForm.SalesPersonId = SalesPerson.Id;
            return Page();
        }
        public IActionResult OnPost()
        {
            SalesPerson = _context.SalesPerson.Find(FireSPForm.SalesPersonId);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            SalesPerson.LeavingDate = FireSPForm.FireDate;

            _context.SaveChanges();

            return RedirectToPage("/Forms/FireSalesPersonForm", new { id = SalesPerson.Id });
        }

    }
}