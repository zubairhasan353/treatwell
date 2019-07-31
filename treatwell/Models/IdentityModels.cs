using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace treatwell.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string ImagePath { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        //public async Task<RoleStore> GenerateRoleIdentityAsync(RoleManager<ApplicationRole> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var roleIdentity = manager.Create(this);
        //    // Add custom user claims here
        //    return roleIdentity;
        //}
    }


    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
        : base(roleStore) { }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationRoleManager(
                new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            return manager;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Categories> categories { get; set; }
        public DbSet<SubCategories> subCategories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProdsUsedInSubCat> prodsUsedInSubCats { get; set; }
        public DbSet<Venues> venues { get; set; }
        public DbSet<VenueImages> VenueImages { get; set; }
        public DbSet<VenueServices> VenueServices { get; set; }
        public DbSet<LogInDetails> LogInDetails { get; set; }
        public DbSet<BookingDaysTime> BookingDaysTimes { get; set; }
        public DbSet<EmployeeAvailability> EmployeeAvailabilities { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<CustomerBooking> CustomerBookings { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<CustomerBookingDetails> CustomerBookingDetails { get; set; }
        public DbSet<NewsLetterandMarketing> NewsLetterandMarketing { get; set; }
        public DbSet<CustomerNewLetterandMarketing> CustomerNewLetterandMarketings { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<CustomerReviews> customerReviews { get; set; }
        public DbSet<UserVenues> UserVenues { get; set; }
        public DbSet<UserServices> UserServices { get; set; }
        public DbSet<EmployeeAbsent> EmployeeAbsents { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}