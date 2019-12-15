using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OA.Interface;
using OA.Repo;

namespace WebAPI.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //readonly IGenericRepository<Employee> genericRepository;
        //public EmployeeController(IGenericRepository<Employee> _genericRepository)
        //{
        //    genericRepository = _genericRepository;
        //}
        readonly IEmployeeRepository employeeRepo;

        public EmployeeController(IEmployeeRepository _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            try
            {
                IEnumerable<Employee> emp = await employeeRepo.GetAll();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                BadRequest();
            }
            try
            {
                Employee str = await employeeRepo.GetById(id);
                if (str == null)
                {
                    return NotFound();
                }
                return Ok(str);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Save([FromBody]Employee value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    #region TestCode
                    //Employee account = new Employee
                    //{
                    //    Id = 1003,
                    //    Name = "James",
                    //    Email = "james@example.com",
                    //    Department = "Medicine"
                    //};

                    //var jsonString = JsonConvert.SerializeObject(account, Formatting.Indented);
                    //var myJsonObject = JsonConvert.DeserializeObject<Employee>(jsonString); 
                    #endregion
                    var postId = await employeeRepo.Insert(value);
                    if (postId > 0) return Ok(postId); else return NotFound();
                }
                catch (Exception ex)
                {
                    //_logger.LogCritical(ex.Message);
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Employee value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRepo.Update(id, value);
                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var result = 0;
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await employeeRepo.Remove(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
