using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.User;

namespace TopLearn.web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userservice;
        private TopLearnContext _context;
        public AccountController(IUserService userService,TopLearnContext context)
        {
            _userservice=userService;
            _context = context;
        }
        public IActionResult Register()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel register )
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            if (_userservice.IsExistEmail(Fixetext.fixemail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل تکراری میباشد");
                return View("Register");
            }
            if (_userservice.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراری میباشد");
                return View("Register");
            }

            var user = new User()
            {
                UserName=register.UserName,
                Email=Fixetext.fixemail(register.Email),
                Password=register.Password,
                RegisterDate=DateTime.Now
            };

            _context.Add(user);
            _context.SaveChanges(); 

            return View("SuccesRegister",user);
        }

        [Route("LogIn")]
        public IActionResult LogIn(bool EditProfile=false)
        {
            ViewBag.EditProfile = EditProfile; 
            return View();
        }
        [Route("LogIn")]
        [HttpPost]
        public IActionResult LogIn(LogInViewModel logIn)
        {
            if (!ModelState.IsValid)
            {
                return View(logIn);
            }
            var user = _userservice.LogInUser(logIn);
            if (user!=null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal=new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent=logIn.RememberMe
                };
                HttpContext.SignInAsync(principal,properties);
                return RedirectToAction("Index","UserPanel");
            }
            ModelState.AddModelError("Email", "کاربری با این مشخصات وجود ندارد");
            return View(logIn);

        }
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("LogIn");
        }

        public IActionResult Forgotpassword()
        {

            return View();
        }
        [Route("LogOut")]
        [HttpPost]
        public IActionResult Forgotpassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
            {
                return View(forgot);
            }

            string fixedemail = Fixetext.fixemail(forgot.Email);
            User user = _userservice.getpassbyemail(fixedemail);
            if(user == null)
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده موجود نمی باشد");
                return View(forgot);
            }

            return View();
        }
    }
}
