using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio.Models;

namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
    public class SkillController : Controller
    {
        StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
        public ActionResult Index()
        {

            var values = db.TBL_Skill.ToList();
            return View(values);
        }
        public ActionResult DeleteSkill(int id)
        {

            var value = db.TBL_Skill.Find(id);
            db.TBL_Skill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddSkill()
        {

            return View();

        }
        [HttpPost]

        public ActionResult AddSkill(TBL_Skill skill)
        {
            
            db.TBL_Skill.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UpdateSkill(int id)
        {

            var value = db.TBL_Skill.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateSkill(TBL_Skill skill)
        {

            var value = db.TBL_Skill.Find(skill.SkillId);
            value.SkillName = skill.SkillName;
            value.Title = skill.Title;
            value.Value = skill.Value;
            value.Description = skill.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}