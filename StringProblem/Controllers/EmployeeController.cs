using StringProblem.Helper;
using StringProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration; 

namespace StringProblem.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empData"></param>
        /// <returns></returns>
        public JsonResult GetEmployee(string empData)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            var reply = HttpClientHelper.GetAsync(ConfigurationManager.AppSettings["ServiceURL"]  +  "api/Employee/GetEmployeeData?param=" + empData);
            model.EmployeeData = JsonConvert.DeserializeObject<List<string>>(reply); ;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}