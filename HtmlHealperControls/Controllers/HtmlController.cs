using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlHealperControls.Models;

namespace HtmlHealperControls.Controllers
{
    public class HtmlController : Controller
    {
        // GET: Html
        public ActionResult Index()
        {
            return View("HtmlInput");
        }
        public ActionResult Demo()
        {
            return View("DemoView");
        }
    }
}