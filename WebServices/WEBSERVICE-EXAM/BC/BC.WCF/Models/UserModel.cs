using BC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BC.WCF.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public static Expression<Func<ApplicationUser, UserModel>> FromUser
        {
            get
            {
                return g => new UserModel
                {
                    Id = g.Id,
                    Username = g.UserName
                };
            }
        }

        public UserModel(ApplicationUser user)
        {
            this.Id = user.Id;
            this.Username = user.UserName;
        }

        public UserModel()
        {

        }
    }
}