
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
    public class MessageController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        // GET: MessageController
        public ActionResult Index()
        {
           
            var values = db.TBL_Message.Where(x => x.isRead == false).ToList();
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            
            var message = db.TBL_Message.Find(id);
            message.isRead = true;
            db.SaveChanges();
            return View(message);
        }
        public ActionResult ReadMessages()
        {
            var values = db.TBL_Message.Where(x => x.isRead == true).ToList();
            return View(values);

        }
    }
}