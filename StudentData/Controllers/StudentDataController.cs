using StudentData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentData.Controllers
{
    public class StudentDataController : Controller
    {
        // GET: StudentData
        public ActionResult Index()
        {
            return View();
        }

        //public ViewResult Main()
        //{
        //   /* var context = new STUDENTDATAEntities();*/
        //    /*var model = context.Logins.ToList();*/
        //    return View();
        //}

        public ViewResult Edisplay()
        {
            var context = new STUDENTDATAEntities();
            var model = context.Studentdatas.ToList();
            return View(model);
        }


        /* public ViewResult Admin()
         {
             var context = new dat;
             var model = context.Logins.ToList();
             return View(model);
         }*/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MyAction(string button)
        {
            return View("Display");
        }

        public ViewResult Display()
        {
            var context = new STUDENTDATAEntities();
            var model = context.Studentdatas.ToList();
            return View(model);
        }
        public ActionResult Find(string id)
        {
            int stuID = int.Parse(id);
            var context = new STUDENTDATAEntities();
            var model = context.Studentdatas.FirstOrDefault((e) => e.stuid == stuID);
            return View(model);
        }
        [HttpPost]
        public ActionResult Find(Studentdata stu)
        {
            var context = new STUDENTDATAEntities();
            var model = context.Studentdatas.FirstOrDefault((e) => e.stuid == stu.stuid);
            model.stufname = stu.stufname;
            model.stumname = stu.stumname;
            model.stulname = stu.stulname;
            model.stuaddress = stu.stuaddress;
            model.stuphone = stu.stuphone;
            model.stucourse = stu.stucourse;
            model.stuyear = stu.stuyear;
            /*model.eventname = emp.eventname;
            model.eventplace = emp.eventplace;
            model.eventdate = emp.eventdate;
            model.eventcost = emp.eventcost;*/
            context.SaveChanges();
            return RedirectToAction("Display");
        }
        public ViewResult AddStudent()
        {
            var model = new Studentdata();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddStudent(Studentdata stu)
        {
            var context = new STUDENTDATAEntities();
            context.Studentdatas.Add(stu);
            context.SaveChanges();
            return RedirectToAction("Display");
        }
        public ActionResult DeleteEmployee(string id)
        {
            int stuId = int.Parse(id);
            var context = new STUDENTDATAEntities();
            var model = context.Studentdatas.FirstOrDefault((e) => e.stuid == stuId);
            context.Studentdatas.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}
    
