namespace Articles.Web.Controllers
{
    using Articles.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseController : ApiController
    {
        private IArticlesData data;

        public BaseController(IArticlesData data)
        {
            this.data = data;
        }
    }
}
