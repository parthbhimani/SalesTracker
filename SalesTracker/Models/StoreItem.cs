using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    public class StoreItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [Display(Name = "Cost Price")]
        [Range(0, Int32.MaxValue)]
        public decimal CostPrice { get; set; }

        [Required]
        [Display(Name = "Selling Price")]
        [Range(0, Int32.MaxValue)]
        [CustomValidation(typeof(StoreItem), "SellingPriceValidation")]
        public decimal SellingPrice { get; set; }

        public ICollection<Sale> Sales { get; set; }

        [NotMapped]
        public decimal profitMargin
        {
            get { return SellingPrice - CostPrice; }
        }
        
        public static ValidationResult SellingPriceValidation(decimal? SellingPrice, ValidationContext context)
        {
            if (SellingPrice == null)
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as StoreItem;
            if (instance == null)
            {
                return ValidationResult.Success;
            }
            if (SellingPrice > instance.CostPrice)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Selling price must be grater than Cost price");
        }
    }
}
