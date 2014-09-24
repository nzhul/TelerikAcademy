using BC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BC.Web.Models
{
    public class NotificationModel
    {
        public static Expression<Func<Notification, NotificationModel>> FromNotification
        {
            get
            {
                return n => new NotificationModel
                {
                    Id = n.Id,
                    Message = n.Message,
                    DateCreated = n.DateCreated,
                    Type = n.Type,
                    State = n.State.ToString(),
                    GameId = n.GameId,
                };
            }
        }

        public NotificationModel()
        {

        }

        public NotificationModel(Notification notification)
        {
            this.Id = notification.Id;
            this.Message = notification.Message;
            this.DateCreated = notification.DateCreated;
            this.Type = notification.Type;
            this.State = notification.State.ToString();
            this.GameId = notification.GameId;
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public int GameId { get; set; }
    }
}