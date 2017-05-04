using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RunsLive.Models.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.VodRequests = new List<VodRequest>();
            this.StreamRequests = new List<StreamRequest>();
            this.GameRequestses = new List<GameRequest>();
        }
        public virtual ICollection<GameRequest> GameRequestses { get; set; }

        public virtual ICollection<VodRequest> VodRequests { get; set; }

        public virtual ICollection<StreamRequest> StreamRequests { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
