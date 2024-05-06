using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(TBL_Admin admin)
        {

            var values = db.TBL_Admin.FirstOrDefault(x => x.UserName == admin.UserName&& x.Password == admin.Password);
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["username"] = values.UserName;
                return RedirectToAction("Index", "About");
            }
        }
    }
}