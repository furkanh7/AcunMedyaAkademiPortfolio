using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        public ActionResult Index()
        {

            var values = db.TBL_Service.ToList();
            return View(values);
        }
        public ActionResult DeleteService(int id)
        {

            var value = db.TBL_Service.Find(id);
            db.TBL_Service.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddService()
        {

            return View();
        
        }
        [HttpPost]

        public ActionResult AddService(TBL_Service service)
        {
            service.ServiceStatus = false;
            db.TBL_Service.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }
        public ActionResult UpdateService(int id)
        {

            var value = db.TBL_Service.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateService(TBL_Service service)
        {

            var value = db.TBL_Service.Find(service.ServiceId);
            value.ServiceName = service.ServiceName;
            value.ServiceStatus = service.ServiceStatus;
            value.ServiceIconUrl = service.ServiceIconUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakeActive(int id)
        {
            var value = db.TBL_Service.Find(id);
            value.ServiceStatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MakePassive(int id)
        {
            var value = db.TBL_Service.Find(id);
            value.ServiceStatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}