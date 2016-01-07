using Microsoft.AspNet.Mvc;
using HelloMvc.Models;
using Microsoft.AspNet.Authorization;
using System.Security.Claims;
using Microsoft.AspNet.Authentication.Cookies;
namespace HelloMvc.Controllers
{
    
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public IActionResult Login(AuthUser authUser)
        {
            if (ModelState.IsValid)
            {
                if (authUser.Username == "admin" && authUser.Password == "admin")
                {
                    var claims = new[] { new Claim("name", authUser.Username), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return Redirect("~/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("","Login failed. Please check Username and/or password");
                }
            }
            
            return View();
        }
    }
}