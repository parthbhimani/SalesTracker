using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models.Forms
{
    public class AwardNoticeForm
    {
        public AwardNoticeForm()
        {
            EntryDate = DateTime.Today;
        }
        public int SalesPersonId { get; set; }

        public bool isAward { get; set; }

        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(AwardNoticeForm), "EntryDateValidation")]
        public DateTime EntryDate { get; set; }

        public static ValidationResult EntryDateValidation(DateTime? EntryDate, ValidationContext context)
        {
            if (EntryDate == null)
            {
                return ValidationResult.Success;
            }
            var futureDate = DateTime.Today.AddDays(15);
            var pastDate = DateTime.Today.AddDays(-15);
            if (pastDate < EntryDate && EntryDate < futureDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Entry date must be within 15 days range [{pastDate.ToShortDateString()}-{futureDate.ToShortDateString()}]");
        }
    }
}
