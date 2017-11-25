using BeatBox.DAL.ORM.Entity;
using BeatBox.UI.Models.AccountVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BeatBox.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Redirect("/");
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVm)
        {
            if (ModelState.IsValid)
            {
                var exist = DataService.Service.WebUserService.GetByActiveState().Any(x => x.Email == loginVm.Email && x.Password == loginVm.Password);

                if (exist)
                {
                    var currentUser = DataService.Service.WebUserService.GetByActiveState().FirstOrDefault(x => x.Email == loginVm.Email);

                    string cookie = $"{currentUser.Role}-{currentUser.Id}-{currentUser.Name} {currentUser.LastName}-{currentUser.Email}";

                    FormsAuthentication.SetAuthCookie(cookie, true);

                    return Redirect("/");
                }
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpVM singUpVm)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                var isExist = DataService.Service.WebUserService.GetAll().Any(x => x.Email == singUpVm.Email);

                if (!isExist)
                {
                    WebUser newUser = new WebUser()
                    {
                        Email = singUpVm.Email,
                        Password = singUpVm.Password,
                        Name = singUpVm.FirstName,
                        LastName = singUpVm.LastName,
                        Role = "user",
                    };
                    result = DataService.Service.WebUserService.Insert(newUser);
                }
            }
            if (result != 0)
                return Redirect("/Account/Login");
            else
                return Redirect("/admin/Account/SingUp");
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return Redirect("/account/login");
        }
    }


}