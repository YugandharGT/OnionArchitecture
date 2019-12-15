using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OA.Web.Models;
using OA.Web.Utility;
using OA.Web.Factory;
using ApiHelper;

namespace OA.Web.Controllers
{
    public class EmployeeUIController : Controller
    {

        readonly IOptions<MySettingsModel> appSettings; //strongly typed config

        public EmployeeUIController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        public JsonResult Details()
        {
            var roolUrl = appSettings.Value.WebApiBaseUrl;
            var data = new ApiClient(roolUrl).GetUsers();
            return Json(data.Result.ToList());
        }

        public ViewResult Edit()
        {
           
            return View();
        }

    }
}