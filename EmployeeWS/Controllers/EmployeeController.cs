using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Interface;

namespace EmployeeWS.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> GetEmployeeData(string param)
        {
           var reply = _employee.GetData(param);

           return reply;
        }

    }
}
