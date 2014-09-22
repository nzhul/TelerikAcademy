using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Articles.WCF.Models
{
    public class AlertModel
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public static Expression<Func<Alert, AlertModel>> FromAlert
        {
            get
            {
                return a => new AlertModel
                {
                    Content = a.Content,
                    Id = a.Id
                };
            }
        }
    }
}