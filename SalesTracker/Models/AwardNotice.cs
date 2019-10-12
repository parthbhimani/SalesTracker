using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    public class AwardNotice
    {
        [Key]
        public int Id { get; set; }

        public bool isNotice { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(AwardNotice), "EntryDateValidation")]
        public DateTime EntryDate { get; set; }

        [Required]
        [Display(Name = "Sales Person")]
        public int SalesPersonId { get; set; }
        public SalesPerson SalesPerson { get; set; }


        [NotMapped]
        public bool IsAward
        {
            get { return !isNotice; }
        }


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
