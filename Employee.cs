using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBasicsCSharp01
{
    internal class Employee
    {
        public string FullName { get; private set; }
        public decimal Salary { get; private set; }

        public Employee(string? fullName, decimal sallary)
        {
            if (string.IsNullOrEmpty(fullName) || fullName.Length < 5)
            {
                throw new Exception("Full name should be more then 5 characters long");
            }

            if (sallary < 0)
            {
                throw new Exception("Salary cannot be negative.");
            }

            FullName = fullName;
            Salary = sallary;
        }
    }
}
