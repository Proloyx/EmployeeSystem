using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeSystem.Data;
using EmployeeSystem.Models;

namespace EmployeeSystem.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IEmployeeRepository _employees;

        public CreateModel(IEmployeeRepository employees)
        {
            _employees = employees;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _employees.AddEmployeeAsync(Employee);

            return RedirectToPage("./Index");
        }
    }
}
