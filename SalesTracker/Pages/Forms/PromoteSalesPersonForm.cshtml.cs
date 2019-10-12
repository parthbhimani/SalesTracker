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
    public class PromoteSalesPersonFormModel : PageModel
    {
        private readonly SalesTrackerContext _context;
        public PromoteSalesPersonFormModel(SalesTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PromoteSFForm PromoteSFForm { get; set; }

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

            PromoteSFForm = new PromoteSFForm();
            PromoteSFForm.SalesPersonId = SalesPerson.Id;
            return Page();
        }
        public IActionResult OnPost()
        {
            SalesPerson = _context.SalesPerson.Find(PromoteSFForm.SalesPersonId);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            SalesPerson.isManager = true;

            _context.SaveChanges();

            return RedirectToPage("/Forms/PromoteSalesPersonForm", new { id = SalesPerson.Id });
        }

    }
}