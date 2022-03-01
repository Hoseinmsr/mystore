using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Entities.User;

namespace TopLearn.web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
       private readonly IUserService _Usersrvice;
        public HomeController(IUserService userService)
        {
            _Usersrvice = userService;
        }
        
        public IActionResult Index()
        {
            return View(_Usersrvice.GetUserInformation(User.Identity.Name));
        }
        [Route("UserPanel/Edit")]
        public IActionResult Edit()
        {
            return View(_Usersrvice.Getinformforedit(User.Identity.Name));
        }
        [Route("UserPanel/Edit")]
        [HttpPost]
        public IActionResult Edit(EditProfileViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }
            
            _Usersrvice.EditProfile(User.Identity.Name, edit);

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/LogIn?EditProfile=true");
        }
        [Route("UserPanel/ChangePassWord")]
        public IActionResult ChangePassWord()
        {
            return View();
        }

        [Route("UserPanel/ChangePassWord")]
        [HttpPost]
        public IActionResult ChangePassWord(ChangePassWordViewModel change)
        {
            if (!ModelState.IsValid)
            {
                return View(change);
            }

            if(!_Usersrvice.compareoldnewpass(change.OldPassWord,User.Identity.Name))
            {
                ModelState.AddModelError("OldPassWord", "رمز وارد شده صحیح نمیباشد");
                return View(change);
            }
            _Usersrvice.changepassword(User.Identity.Name, change.Password);
            ViewBag.isSuccess = true;
            return View();
        }


     
       
    }
}
