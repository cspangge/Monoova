using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Adapter;
using Adapter.Services;

namespace Monoova.Controllers
{
    public class HomeController : Controller
    {
        private readonly Tools _tools;
        
        public HomeController()
        {
            var monoovaHelper = new MonoovaHelper();
            _tools = new Tools(monoovaHelper);
        }
        
        public async Task<ViewResult> Index()
        {
            await _tools.Ping();
            await _tools.ValidateAbn("15167507039");
            await _tools.ValidateBsb("062-624");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}