using System;
using System.Collections.Generic;

namespace SampleBackendAPI.Models
{
    public interface IEmployeeRepository
    {
        void Add(Employee item);
        IEnumerable<Employee> GetAll();
        Employee Find(string key);
        Employee Remove(string key);
        void Update(Employee item, string key);
    }

}
