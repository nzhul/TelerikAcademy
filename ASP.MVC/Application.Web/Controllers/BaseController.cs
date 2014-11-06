using Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Application.Web.Controllers
{
    public class BaseController: Controller
    {
        protected IUoWData Data;
        public BaseController(IUoWData data)
        {
            this.Data = data;
        }

        public BaseController()
            :this(new UoWData())
        {
        }
    }
}