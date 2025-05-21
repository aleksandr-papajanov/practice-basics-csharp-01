using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBasicsCSharp01
{
    internal class EmployeeRegistry
    {
        private readonly List<Employee> _employees = new();

        public IReadOnlyList<Employee> Employees => _employees;

        public void Add(Employee newEmployee)
        {
            if (_employees.Any(e => e.FullName == newEmployee.FullName))
            {
                throw new Exception("Employee already exists.");
            }

            _employees.Add(newEmployee);
        }

        public void DeleteByName(string? fullName)
        {
            var e = _employees.FirstOrDefault(e => e.FullName == fullName);
            
            if (e == null)
            {
                throw new Exception("Employee with a specified name hasn't been found.");
            }

            _employees.Remove(e);
        }
    }
}
