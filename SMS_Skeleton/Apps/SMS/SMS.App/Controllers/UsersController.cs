using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SMS.App.ViewModels.UserModels;
using SMS.Services;

namespace SMS.App.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService usersService;

        public UsersController(IUserService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet(Url = "/Users/Login")]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.usersService.GetUserOrNull(input.Username, input.Password);
            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);
            return this.Redirect("/");
        }

        [HttpGet(Url = "/Users/Register")]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            var userId = this.usersService.CreateUser(input.Username, input.Email, input.Password);

            this.SignIn(userId, input.Username, input.Email);
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}