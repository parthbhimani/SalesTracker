using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        [StringLength(500)]
        public string DepartmentName { get; set; }
        
        public ICollection<SalesPerson> SalesPersons { get; set; }

        public ICollection<StoreItem> StoreItems { get; set; }
    }
}
