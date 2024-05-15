using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult DefaultFeaturePartial()
        {
            ViewBag.project = db.TBL_Project.Count();
            ViewBag.testimonial = db.TBL_Testimonial.Count();
            ViewBag.skill = db.TBL_Skill.Count();
            var values = db.TBL_Feature.ToList();
            return PartialView(values);


        }
        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.TBL_About.ToList();
            return PartialView(values);


        }


        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();

        }
        [HttpPost]
        public ActionResult SendMessage(TBL_Message message)
        {

            message.isRead = false;
            db.TBL_Message.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TBL_Service.Where(x=>x.ServiceStatus==true).ToList();

            return PartialView(values);
        }
        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TBL_Skill.ToList();
            return PartialView(values);


        }
        public PartialViewResult DefaultProjectPartial()
        {
            var values = db.TBL_Project.ToList();
            return PartialView(values);


        }
        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.TBL_Testimonial.ToList();
            return PartialView(values);


        }
        public PartialViewResult DefaultContactInfoPartial()
        {
            var values = db.TBL_Contact.ToList();
            return PartialView(values);


        }
        public PartialViewResult UILayoutFooterPartial()
        {
            var values = db.TBL_SocialMedia.ToList();
            return PartialView(values);

        }
    }


}