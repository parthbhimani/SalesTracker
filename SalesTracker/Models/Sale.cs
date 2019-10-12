using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sales Person")]
        public int SalesPersonId { get; set; }
        public SalesPerson SalesPerson { get; set; }

        [Required]
        [Display(Name = "Store Item")]
        [CustomValidation(typeof(Sale), "DepartmentValidation")]
        public int StoreItemId { get; set; }
        public StoreItem StoreItem { get; set; }

        [Required]
        [Range(0, 50)]
        public int Quantity { get; set; }

        [NotMapped]
        public decimal totalSaleRevenue
        {
            get
            {
                if (StoreItem != null) {
                    return StoreItem.profitMargin * Quantity;
                } else return 0;
                
            }
        }

        public static ValidationResult DepartmentValidation(int? StoreItemId, ValidationContext context)
        {
            if (StoreItemId == null)
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Sale;
            if (instance == null)
            {
                return ValidationResult.Success;
            }

            var dbContext = context.GetService(typeof(SalesTrackerContext)) as SalesTrackerContext;
            var salesPersonInstance = dbContext.SalesPerson.FirstOrDefault(x => x.Id == instance.SalesPersonId);
            var storeItemInstance = dbContext.StoreItem.FirstOrDefault(x => x.Id == instance.StoreItemId);

            if (salesPersonInstance == null || storeItemInstance == null)
            {
                return ValidationResult.Success;
            }
           
            if (salesPersonInstance.DepartmentId != storeItemInstance.DepartmentId)
            {
                return new ValidationResult("Sales person cannot sell item from other department");
            }

            return ValidationResult.Success;
        }
    }
}
