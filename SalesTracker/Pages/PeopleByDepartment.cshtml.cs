using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalesTracker.Models;

namespace SalesTracker.Pages
{
    public class PeopleDepartmentModel : PageModel
    {
        private SalesTrackerContext _context;

        public ICollection<Department> departments { get; set; }

        public ICollection<SalesPerson> FiredSalesPeople { get; set; }
        public PeopleDepartmentModel(SalesTrackerContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            departments = _context.Department.Include(dep => dep.SalesPersons).ThenInclude(sp => sp.AwardNotice).ToArray();
            FiredSalesPeople = _context.SalesPerson.Where(s => s.IsEmployed != true).ToArray();


        }
    }
}