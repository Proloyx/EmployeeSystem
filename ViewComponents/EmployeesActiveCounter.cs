using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.ViewComponents
{
    public class EmployeesActiveCounterViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employees;

        public EmployeesActiveCounterViewComponent(IEmployeeRepository employees)
        {
            _employees = employees;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var counter = new CounterViewModel
            {
                Active = await _employees.CountActiveAsync(),
                Inactive = await _employees.CountNotActiveAsync()
            };

            return View(counter);
        }

        public class CounterViewModel
        {
            public int Active { get; set; }
            public int Inactive { get; set; }
        }
    }
}