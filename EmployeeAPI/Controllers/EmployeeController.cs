using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeRepository.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Employee emp)
        {
            if (ModelState.IsValid)
                employeeRepository.Add(emp);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            emp.EmployeeId = id;
            if (ModelState.IsValid)
                employeeRepository.Update(emp);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }
    }
}
