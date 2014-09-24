namespace BC.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {
            this.UserRank = 2; // TODO: Implement the real logic for finding the Rank
            this.Notifications = new HashSet<Notification>();
        }

        public int WinsCount { get; set; }
        public int LossesCount { get; set; }

        public int UserRank { 
            get
            {
                return 100 * this.WinsCount + 15 * this.LossesCount;
            }
            set
            {

            }
        }

        public ICollection<Notification> Notifications { get; set; }
    }
}
