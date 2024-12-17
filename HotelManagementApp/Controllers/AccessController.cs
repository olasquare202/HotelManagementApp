using HotelManagementApp.Data;
using HotelManagementApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

namespace HotelManagementApp.Controllers
{
    public class AccessController : Controller
    {
        private readonly GuestDbContext _guestDbContext;

        public AccessController(GuestDbContext guestDbContext)
        {
            _guestDbContext = guestDbContext;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            if(claimsUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(VMLogin vMLogin)
        {
            //if (ModelState.IsValid)
            if(vMLogin.Email == "haulexgem@gmail.com" &&
               vMLogin.Password == "123")
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, vMLogin.Email),
                    new Claim("otherProperties", "ExampelRole")
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), properties);
                TempData["success"] = "Login was Successful";
                return RedirectToAction("Index", "Home");
            }
            ViewData["ValidateMessage"] = "Invalid Credentials";
            return View();
        }
        //public IActionResult Register()
        //{
        //    ClaimsPrincipal claimsUser = HttpContext.User;
        //    if (claimsUser.Identity.IsAuthenticated)
        //        return RedirectToAction("Index", "Home");
        //    return View();
        //}
        //[HttpPost]
        //public async Task <IActionResult> Register([FromBody] VMRegister vMRegister)
        //{
        //    if (ModelState.IsValid)
        //    {
                
        //        {
        //            Email = vMRegister.Email,
        //            Password = vMRegister.Password,
        //            Role = vMRegister.Role,
        //        };

        //        await _guestDbContext.AddAsync(user);
        //        await _guestDbContext.SaveChangesAsync();
        //    }
        //    //if (claimsUser.Identity.IsAuthenticated)
        //        return RedirectToAction("login", "Access");
        //    //return View();
        //}
    }
}
