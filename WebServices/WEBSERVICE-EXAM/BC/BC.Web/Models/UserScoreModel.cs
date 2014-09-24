using BC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BC.Web.Models
{
    public class UserScoreModel
    {

        public static Expression<Func<ApplicationUser, UserScoreModel>> FromUserScoreModel
        {
            get
            {
                return g => new UserScoreModel
                {
                    Username = g.UserName,
                    Rank = g.UserRank
                };
            }
        }

        public UserScoreModel(ApplicationUser user)
        {
            this.Username = user.UserName;
            this.Rank = user.UserRank;
        }

        public UserScoreModel()
        {

        }
        public string UserId { get; set; }
        public string Username { get; set; }
        public int Rank { get; set; }
    }
}