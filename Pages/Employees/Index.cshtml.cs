using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeSystem.Data;
using EmployeeSystem.Models;

namespace EmployeeSystem.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _employees;

        public IndexModel(IEmployeeRepository employees)
        {
            _employees = employees;
        }

        public List<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _employees.GetAllEmployeesAsync();
        }
    }
}
