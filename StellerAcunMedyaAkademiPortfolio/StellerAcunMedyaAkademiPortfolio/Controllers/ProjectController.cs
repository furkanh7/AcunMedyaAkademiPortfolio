using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaAkademiPortfolio.Models;


namespace StellerAcunMedyaAkademiPortfolio.Controllers
{
   
        // GET: Project
        public class ProjectController : Controller
        {
            StellerAcunMedyaDBEntities db = new StellerAcunMedyaDBEntities();
            public ActionResult Index()
            {
                var values = db.TBL_Project.ToList();
                return View(values);
            }

            public ActionResult DeleteProject(int id)
            {
                var value = db.TBL_Project.Find(id);
                db.TBL_Project.Remove(value);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            [HttpGet]
            public ActionResult AddProject()
            {
                return View();
            }

            [HttpPost]
            public ActionResult AddProject(TBL_Project project)
            {
                db.TBL_Project.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            [HttpGet]       
            public ActionResult UpdateProject(int id)
            {
            var value = db.TBL_Project.Find(id);
            return View(value);
           

            }
            [HttpPost]
            public ActionResult UpdateProject(TBL_Project project)
            {
            var value = db.TBL_Project.Find(project.ProjectId);
            value.Description = project.Description;
            value.ImageUrl = project.ImageUrl;
            value.GitHubUrl = project.GitHubUrl;
            value.Title = project.Title;
            db.SaveChanges();
            return RedirectToAction("Index");

        
            }



        }
    }
