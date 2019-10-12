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
    public class AwardNoticeSPFormModel : PageModel
    {
        private readonly SalesTrackerContext _context;
        public AwardNoticeSPFormModel(SalesTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AwardNoticeForm AwardNoticeForm { get; set; }

        public SalesPerson SalesPerson { get; set; }

        public string ButtonActionString { get {
                if (AwardNoticeForm.isAward)
                {
                    return "Felicitate";
                }
                else {
                    return "Notify";
                }
            }
        }

        public IActionResult OnGet(int? id, bool isAward)
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

            AwardNoticeForm = new AwardNoticeForm();
            AwardNoticeForm.SalesPersonId = SalesPerson.Id;
            AwardNoticeForm.isAward = isAward;
            return Page();
        }
        public IActionResult OnPost()
        {
            SalesPerson = _context.SalesPerson.Find(AwardNoticeForm.SalesPersonId);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            AwardNotice an = new AwardNotice();
            an.SalesPersonId = AwardNoticeForm.SalesPersonId;
            an.EntryDate = AwardNoticeForm.EntryDate;
            an.isNotice = AwardNoticeForm.isAward;

            _context.AwardNotice.Add(an);
            _context.SaveChanges();

            return RedirectToPage("/AwardsNotices/Details", new { Id = an.Id });
        }
    }
}