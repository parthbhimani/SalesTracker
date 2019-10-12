using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models.Forms
{
    public class FireSPForm
    {

        public FireSPForm()
        {
            FireDate = DateTime.Today;
        }
        public int SalesPersonId { get; set; }

        [Display(Name = "Firing Date")]
        [DataType(DataType.Date)]
        public DateTime FireDate { get; set; }
    }
}
