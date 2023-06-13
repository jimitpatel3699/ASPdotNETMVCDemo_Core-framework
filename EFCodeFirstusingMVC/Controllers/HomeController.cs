using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstusingMVC.Models;

namespace EFCodeFirstusingMVC.Controllers
{
    public class HomeController : Controller
    {
        StudentContext context=new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = context.Students.ToList();
            return View("Index1",data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            int status = 0;
            if(ModelState.IsValid)
            {
                context.Students.Add(s);
                status = context.SaveChanges();
               //ModelState.Clear();//when redirrted to same page used for clear all fields values
               //and here we can also used the viewbag or temp data etc to pass message.
            }
            return View("Status", status);
        }
        public ActionResult Edit(int id)
        {
            Student student = context.Students.Find(id);
            return View("Edit",student);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            context.Entry(s).State=EntityState.Modified;
            context.SaveChanges();
            //return View("Index1");//here this is not working.
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Student student=context.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            //Student student = context.Students.Find(s.Id);
            context.Entry(s).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
           Student student=context.Students.Find(id);
            return View(student);
        }
    }
}