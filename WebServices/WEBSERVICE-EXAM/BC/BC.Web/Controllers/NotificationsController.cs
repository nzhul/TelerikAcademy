namespace BC.Web.Controllers
{
    using BC.Data;
    using BC.Web.Models;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    public class NotificationsController : BaseApiController
    {
        const int defaultPageSize = 10;
        public NotificationsController()
            : this(new BCData(new BCDbContext()))
        {

        }

        public NotificationsController(IBCData data)
            : base(data)
        {
        }



        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(0);
        }

        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            var notifications = GetAllSorted()
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize);
            if (notifications == null)
            {
                return NotFound();
            }
            return Ok(notifications);
        }

        private IEnumerable<NotificationModel> GetAllSorted()
        {

            var userId = this.User.Identity.GetUserId();
            return this.data.Notifications.All()
                .Where(n => n.UserId == userId)
                .OrderBy(g => g.DateCreated)
                .Select(NotificationModel.FromNotification);
        }
    }
}
