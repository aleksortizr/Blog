using Blog_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Blog_MVC.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using static Blog_MVC.Models.LoginModel;
using Blog_Common.DTOs;
using LinqToDB;

namespace Blog_MVC.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly IDataContext _context;

        public IActionResult Index()
        {
            return View();
        }

        public AuthController(IUserService userService, IDataContext context)
        {
            _context = context;
            this.userService = userService;
        }

        [Route("login")]
        public IActionResult LogIn()
        {
            return View(new LogInModel());
        }

        [Route("login")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userService.Authenticate(model.UserName, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("InvalidCredentials", "Could not validate your credentials");
                return View(model);
            }

            return await SignInUser(user);
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userService.Add(model.UserName, model.Password);

            return await SignInUser(user);
        }

        [Route("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("logout")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task<IActionResult> SignInUser(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var identity = new ClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("UserInformation", "Home");
        }
    }
}