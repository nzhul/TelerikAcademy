using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Controllers
{
    public class LaptopsController : BaseController
    {
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}