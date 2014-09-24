namespace BC.Web.Controllers
{
    using BC.Data;
    using System.Web.Http;
    public abstract class BaseApiController : ApiController
    {
        protected IBCData data;

        protected BaseApiController(IBCData data)
        {
            this.data = data;
        }
    }
}
