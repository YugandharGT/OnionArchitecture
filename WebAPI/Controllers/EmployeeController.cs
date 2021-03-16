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
        readonly IEmployeeTaskRepository employeeRepo;

        public EmployeeController(IEmployeeTaskRepository _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        #region Async Operations
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Details()
        {
            try
            {
                IEnumerable<Employee> emp = await employeeRepo.GetAllAsync();
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> Index(int id)
        {
            try
            {
                var str = await employeeRepo.GetByIdAsync(id);
                if (str == null)
                {
                    return NotFound();
                }
                return str;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Employee>> Save(Employee value)
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
                if (value == null)
                {
                    return BadRequest();
                }
                var postId = await employeeRepo.InsertAsync(value);
                if (postId == null)
                {
                    ModelState.AddModelError("Email", "Employee email already in use");
                    return BadRequest(ModelState);
                }
                return CreatedAtAction(nameof(Index), new { id = postId.Id }, postId);
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.Message);
                return BadRequest();
            }
            
            
        }

        // PUT api/values/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> Put(int id, Employee value)
        {
            try
            {
                if (id != value.Id)
                {
                    return BadRequest("Employee Id mismatch");
                }
                var empToUpdate = await employeeRepo.GetByIdAsync(id);
                if (empToUpdate == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                return await employeeRepo.UpdateAsync(value);
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

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var result = await employeeRepo.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound($"Employee with Id={id} not found");
                }
                return await employeeRepo.RemoveAsync(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
