namespace Me.Web.Domain.Controllers
{
    using Archient.Web.Identity.Domain.Entities;
    using Microsoft.AspNet.Identity;

    public class AccountController : Archient.Web.Identity.Domain.Controllers.AccountControllerBase
    {
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
            : base(userManager, signInManager)
        {
        }
    }
}