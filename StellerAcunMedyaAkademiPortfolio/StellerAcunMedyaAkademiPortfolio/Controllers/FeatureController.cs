using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        public ActionResult Index()
        {
            var values = db.TBL_Feature.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TBL_Feature feature)
        {
            db.TBL_Feature.Add(feature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.TBL_Feature.Find(id);
            db.TBL_Feature.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TBL_Feature.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TBL_Feature feature)
        {
            var value = db.TBL_Feature.Find(feature.FeatureId);
            value.NameSurname = feature.NameSurname;
            value.Title = feature.Title;
            value.Job = feature.Job;
            value.ImageUrl = feature.ImageUrl;
            value.CvDownloadUrl = feature.CvDownloadUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}