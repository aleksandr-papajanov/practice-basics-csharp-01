using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBasicsCSharp01
{
    internal class ConsoleUI
    {
        private readonly Dictionary<string, ConsoleUIMenuItem> _menuActions;
        private readonly EmployeeRegistry _registry;
        private bool _terminated = false;


        public ConsoleUI(EmployeeRegistry registry)
        {
            _registry = registry;

            _menuActions = new () {
                { "1", new("Create Employee", AddEmployee) },
                { "2", new("Show Employees", ShowAllEmployees) },
                { "3", new("Delete Employee", DeleteEmployee) },
                { "0", new("Exit", () => _terminated = true) }
            };
        }

        public void Start()
        {
            while (!_terminated)
            {
                foreach (var item in _menuActions)
                {
                    Console.WriteLine($"{item.Key}. {item.Value.Name}");
                }

                Console.Write("Select option: ");

                try
                {
                    if (!_menuActions.TryGetValue(Console.ReadLine(), out var menuItem))
                    {
                        throw new Exception("Invalid option");
                    }

                    menuItem.Action.Invoke();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}. Press any key to continue.");
                    Console.ResetColor();
                    
                    Console.ReadKey();
                }
                finally
                {
                    Console.Write("\n");
                }
            }
        }

        public void AddEmployee()
        {
            Console.Write("Enter employee name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter employee salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out var salary))
            {
                throw new Exception($"Invalid salary");
            }

            var employee = new Employee(name, salary);

            _registry.Add(employee);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Employee {employee.FullName} added with salary {employee.Salary}.");
            Console.ResetColor();
            
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter employee name: ");
            string? name = Console.ReadLine();

            _registry.DeleteByName(name);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee deleted.");
            Console.ResetColor();
        }

        public void ShowAllEmployees()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{_registry.Employees.Count} entries found.");

            foreach (var e in _registry.Employees)
            {
                Console.WriteLine($"Employee: {e.FullName}, Salary: {e.Salary}");
            }

            Console.ResetColor();
        }
    }
}
