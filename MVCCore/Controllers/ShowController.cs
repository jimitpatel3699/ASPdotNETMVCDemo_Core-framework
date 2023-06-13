using Microsoft.AspNetCore.Mvc;

namespace MVCCore.Controllers
{
    public class ShowController : Controller
    {
        public string Index()
        {
            return "Hello from ShowController Index method";
        }
        public string Demo()
        {
            return "Hello from ShowController Demo method";
        }
    }
}
