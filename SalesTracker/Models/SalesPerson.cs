using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    public class SalesPerson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(SalesPerson), "JoiningDateValidation")]
        public DateTime JoiningDate { get; set; }

        [DataType(DataType.Date)]
        [CustomValidation(typeof(SalesPerson), "LeavingDateValidation")]
        public DateTime? LeavingDate { get; set; }

        public bool isManager { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<AwardNotice> AwardNotice { get; set; }

        public ICollection<Sale> Sales { get; set; }

        [NotMapped]
        public string DisplayName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        [NotMapped]
        public bool IsEmployed
        {
            get { return LeavingDate == null; }
        }

        [NotMapped]
        public int AwardsCount
        {
            get
            {
                int count = 0;
                if (AwardNotice != null) {
                    foreach (var awards in AwardNotice)
                    {
                        if (awards.IsAward)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }

        [NotMapped]
        public int NoticesCount
        {
            get
            {
                int count = 0;
                if (AwardNotice != null)
                {
                    foreach (var awards in AwardNotice)
                    {
                        if (awards.isNotice)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }

        [NotMapped]
        public decimal totalSalesRevenue
        {
            get
            {
                decimal revenue = 0;
                if (Sales != null)
                {
                    foreach (var sale in Sales)
                    {
                        revenue += sale.totalSaleRevenue;
                    }
                }
                return revenue;
            }
        }

        public static ValidationResult JoiningDateValidation(DateTime? joiningDate, ValidationContext context)
        {
            if (joiningDate == null)
            {
                return ValidationResult.Success;
            }
            if (joiningDate.Value.Date <= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            string errorMessage = $"Joining date must be a date on or before { DateTime.Today.ToShortDateString() }";
            return new ValidationResult(errorMessage);
        }

        public static ValidationResult LeavingDateValidation(DateTime? leavingDate, ValidationContext context)
        {
            if (leavingDate == null)
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as SalesPerson;
            if (instance == null)
            {
                return ValidationResult.Success;
            }
            if (leavingDate > instance.JoiningDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Leaving date must be after joining date");
        }
    }
}
