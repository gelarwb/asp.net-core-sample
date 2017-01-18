using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using SampleBackendAPI.Models;
using Newtonsoft.Json;

namespace SampleBackendAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        public EmployeeController(IEmployeeRepository empItems)
        {
            EmpItems = empItems;
        }
        public IEmployeeRepository EmpItems { get; set; }

        [HttpGet]
        [EnableCors("MyPolicy")]
        public IEnumerable<Employee> GetAll()
        {
            return EmpItems.GetAll();
            //var data = EmpItems.GetAll().ToList();
            //return new JsonResult() { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet("{id}", Name = "GetEmp")]
        public IActionResult GetById(string id)
        {
            var item = EmpItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        public IActionResult Create([FromBody] Employee item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            EmpItems.Add(item);
            return CreatedAtRoute("GetEmp", new { id = item.Id.ToString() }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Employee item)
        {
            if (item == null || item.Id.ToString() != id)
            {
                return BadRequest();
            }

            var emp = EmpItems.Find(id);
            if (emp == null)
            {
                return NotFound();
            } 

            EmpItems.Update(item, id);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var emp = EmpItems.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            EmpItems.Remove(id);
            return new NoContentResult();
        }


    }

}
