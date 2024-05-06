using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
    public class ContactController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        public ActionResult Index()
        {
            var values = db.TBL_Contact.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = db.TBL_Contact.Find(id);
            db.TBL_Contact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(TBL_Contact contact)
        {
            db.TBL_Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TBL_Contact.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(TBL_Contact contact)
        {

            var value = db.TBL_Contact.Find(contact.ContactId);
            value.Phone = contact.Phone;
            value.Address = contact.Address;
            value.Email = contact.Email;
            value.MapUrl = contact.MapUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}