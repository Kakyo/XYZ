using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xyz = XYZ.Attributes;
using XYZ.Interfaces.Services;

namespace XYZ.Ui.Web.Controllers
{
    public class ParceirosController : Controller
    {
        //
        // GET: /Contato/
        //[xyz.Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            return View();
        }
    }
}