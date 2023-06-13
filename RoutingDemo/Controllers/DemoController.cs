using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingDemo.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public string Index()
        {
            return "Demo controller index method";
        }
        public string Show()
        {
            return "Demo controller show method";
        }
    }
}