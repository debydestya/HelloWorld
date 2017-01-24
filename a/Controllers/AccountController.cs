using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using a.Models.ViewModel;
using a.Models.EntityManager;

namespace a.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUpView USV)
        {
            if(ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName))
                {
                    FormsAuthentication.SetAuthCookie(USV.FirstName, false);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken");
            }
            return View();
        }
    }
}