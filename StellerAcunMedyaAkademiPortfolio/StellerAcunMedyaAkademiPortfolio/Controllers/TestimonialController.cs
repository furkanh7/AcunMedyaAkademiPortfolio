using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        

        public ActionResult Index()
        {
            var values = db.TBL_Testimonial.ToList();
            return View(values);

            
        }



        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TBL_Testimonial testimonial)
        {
            db.TBL_Testimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TBL_Testimonial.Find(id);
            db.TBL_Testimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TBL_Testimonial.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TBL_Testimonial testimonial)
        {
           
            var value = db.TBL_Testimonial.Find(testimonial.TestimonialId);
            value.NameSurname = testimonial.NameSurname;
            value.Description = testimonial.Description;
            value.Title = testimonial.Title;
            value.ImageUrl = testimonial.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");



        }



    }




}