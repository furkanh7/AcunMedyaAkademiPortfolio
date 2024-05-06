using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
     
    public class AboutController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();

        public ActionResult Index()
        {

            var aboutList = db.TBL_About.ToList();
            return View(aboutList);
        }

        public ActionResult DeleteAbout(int id) 
        
        {
            var about = db.TBL_About.Find(id);

            db.TBL_About.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
          
        }
        [HttpGet]

        public ActionResult AddAbout()

        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAbout(TBL_About about)
        {
            db.TBL_About.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");



        }

        public ActionResult UpdateAbout(int id)
        {
            var about = db.TBL_About.Find(id);
            return View(about);

        }

        [HttpPost]

        public ActionResult UpdateAbout(TBL_About about)
        {


            var value = db.TBL_About.FirstOrDefault(x=>x.AboutId == about.AboutId);

            value.NameSurname = about.NameSurname;
            value.Title = about.Title;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;
            db.SaveChanges();


            return RedirectToAction("Index");            
        }


    }
}