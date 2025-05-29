using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSystem.Data;
using EmployeeSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSystem.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync() => await _context.Employees.ToListAsync();
        public async Task<Employee> GetEmployeeByIdAsync(int id) => await _context.Employees.FindAsync(id);

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountActiveAsync() => await _context.Employees.CountAsync(e => e.IsActive);
        public async Task<int> CountNotActiveAsync() => await _context.Employees.CountAsync(e => !e.IsActive);

    }
}