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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Employee")]
    [ApiVersion("1.0")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //readonly IGenericRepository<Employee> genericRepository;
        //public EmployeeController(IGenericRepository<Employee> _genericRepository)
        //{
        //    genericRepository = _genericRepository;
        //}
        readonly IEmployeeTaskRepository employeeRepo;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_employeeRepo"></param>
        public EmployeeController(IEmployeeTaskRepository _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        #region Async Operations
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("EmployeeDetails")]
        public async Task<ActionResult> EmployeeDetails()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveEmployee")]
        public async Task<ActionResult<Employee>> SaveEmployee([FromBody]Employee value)
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
                return CreatedAtAction(nameof(GetEmployeeById), new { id = postId.Id }, postId);
            }
            catch (Exception ex)
            {
                //_logger.LogCritical(ex.Message);
                return BadRequest(ex);
            }
            
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateEmployee/{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] Employee value)
        {
            //try
            //{
                var empToUpdate = await employeeRepo.GetByIdAsync(id);
                //if (empToUpdate == null)
                //{
                //    return NotFound($"Employee with Id = {id} not found");
                //}
                return await employeeRepo.UpdateAsync(value);
            //}
            //catch (Exception ex)
            //{
            //    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbConcurrencyException")
            //    {
            //        return NotFound();
            //    }
            //    return BadRequest();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
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
