using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.ViewModels.User;
using System.Security.Claims;

namespace SEDC.Lamazon.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
       

       
        public IActionResult Login()
        {
            LoginUserViewModel loginUserViewModel = new LoginUserViewModel();
            return View(loginUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginUserViewModel model)
        {
            try 
            {
                if (model == null)
                    return BadRequest();

                UserViewModel userLoginInfo = _userService.LoginUser(model);

                if (userLoginInfo == null)
                    return BadRequest();

                //Generete claims for cookie based auth
                List<Claim> userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, userLoginInfo.Id.ToString()),
                    new Claim(ClaimTypes.Email, userLoginInfo.Email),
                    new Claim(ClaimTypes.Name, userLoginInfo.FullName),
                    new Claim(ClaimTypes.Role, userLoginInfo.Role.Key)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims,CookieAuthenticationDefaults.AuthenticationScheme );

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);


                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel model)
        {
            try 
            {
                if (model == null)
                    return BadRequest();

                //TODO: We will fix this
                model.RoleId = 2;

                _userService.RegisterUser(model);

                return View("SuccessRegistration");
            }

            catch (Exception ex)
            { 
                return View("Error");
            }

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");


        }
    }
}
