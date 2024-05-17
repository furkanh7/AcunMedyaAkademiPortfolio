using StellerAcunMedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        public ActionResult Index()
        {
            var values = db.TBL_SocialMedia.ToList();
            return View(values);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.TBL_SocialMedia.Find(id);
            db.TBL_SocialMedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TBL_SocialMedia SocialMedia)
        {

            db.TBL_SocialMedia.Add(SocialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TBL_SocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TBL_SocialMedia SocialMedia)
        {
            var value = db.TBL_SocialMedia.Find(SocialMedia.SocialMediaId);
            value.SocialMediaName = SocialMedia.SocialMediaName;
            value.Icon = SocialMedia.Icon;
            value.Url = SocialMedia.Url;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}