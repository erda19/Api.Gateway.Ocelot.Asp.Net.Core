using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ocelot.Api.Test.Asp.Net.Core.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        [HttpGet]
        public  JsonResult Get()
        {
            return Json(new { Text = "Hello World" });
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
