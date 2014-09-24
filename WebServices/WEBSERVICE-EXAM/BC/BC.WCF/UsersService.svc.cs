using BC.Data;
using BC.Models;
using BC.WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BC.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsersService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsersService.svc or UsersService.svc.cs at the Solution Explorer and start debugging.
    public class UsersService : IUsersService
    {
        private BCData data;

        public UsersService()
        {
            this.data = new BCData(BCDbContext.Create());
        }
        public IEnumerable<UserModel> GetUsers()
        {
            var users = this.data.Users.All()
                .Select(UserModel.FromUser).ToList();

            return users;
        }
    }
}
