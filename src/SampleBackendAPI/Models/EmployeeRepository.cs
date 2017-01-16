using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SampleBackendAPI.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static ConcurrentDictionary<string, Employee> _emp =
              new ConcurrentDictionary<string, Employee>();

        private EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            var data = _context.Employees;
            return data;
        }

        public void Add(Employee item)
        {
            _context.Employees.Add(item);
            _context.SaveChanges();
        }

        public Employee Find(string key)
        {
            Employee item;
            item = _context.Employees.Find(Convert.ToInt32(key));
            return item;
        }

        public Employee Remove(string key)
        {
            Employee item = _context.Employees.Find(Convert.ToInt32(key));
            _context.Employees.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public void Update(Employee item, string key)
        {
            Employee curritem = _context.Employees.Find(Convert.ToInt32(key));
            _context.Entry(curritem).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }



    }
}
