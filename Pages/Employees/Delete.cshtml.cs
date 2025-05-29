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
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employees;

        public DeleteModel(IEmployeeRepository employees)
        {
            _employees = employees;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var employee = await _employees.GetEmployeeByIdAsync(id);

            if (employee is not null)
            {
                Employee = employee;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _employees.DeleteEmployeeAsync(id);

            return RedirectToPage("./Index");
        }
    }
}
