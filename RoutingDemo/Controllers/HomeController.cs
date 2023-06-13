using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Home controller index method";
        }
        //atribute routes URL
        [Route("jimit/{sid}/patel")]
        public string Show()
        {
            return "Home controller show method";
        }
    }
}