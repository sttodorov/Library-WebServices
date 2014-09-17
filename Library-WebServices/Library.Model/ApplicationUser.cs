namespace Library.Model
{
    using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Book> takenBooks;

        public ApplicationUser()
            :base()
        {
            this.TakenBooks = new HashSet<Book>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public ICollection<Book> TakenBooks
        {
            get
            {
                return this.takenBooks;
            }
            set
            {
                this.takenBooks = value;
            }
        }
    }
}
