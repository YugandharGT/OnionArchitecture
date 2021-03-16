using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OA.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        readonly IEmailRepository emailRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailRepository"></param>
        public EmailController(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       [HttpGet]
       [Route("GetEmailHistory")]
       public async Task<IActionResult> GetEmailHistory()
       {
            try
            {
               var result = await this.emailRepository.GetEmailTracksAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
       }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetFilteredEmails")]
        public IActionResult GetFilteredEmails(string emailFilter)
        {
            try
            {
                //To handle client code request
                EmailFilter customerJson = JsonConvert.DeserializeObject<EmailFilter>(emailFilter);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
