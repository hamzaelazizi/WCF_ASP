using StudentWcfConsume.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWcfConsume.Controllers
{
    public class StudentController : Controller
    {
        Service1Client sc = new Service1Client();
        public ActionResult GetStudents()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.List = sc.GetAllStudents().ToList<Student>();
            ViewBag.Fils = sc.GetFils().ToList<String>();
            return View("GetStudents");
        }

        public ActionResult GetStudentsByFil(String Fil)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.List = sc.GetStudentsByFil(Fil).ToList<Student>();
            ViewBag.Fils = sc.GetFils().ToList<String>();
            if(sc.GetFils().Count() != 0) return View("GetStudents");
            else return RedirectToAction("GetStudents", "Student");
        }
        public ActionResult GetStudent(string cin)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.st = sc.GetStudent(cin);
            if(ViewBag.st!=null) return View();
            else return RedirectToAction("GetStudents", "Student");
        }
        public ActionResult CreateStudent( )
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent(Student st)
        {
            sc.CreateStudent(st);
            return GetStudents();
        }
        public ActionResult UpdateStudent(string cin)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!(cin is null)) ViewBag.st = sc.GetStudent(cin);
            else ViewBag.st = new { cin = "na" };
            return View();
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student st)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            sc.UpdateStudent(st);
            return GetStudents();
        }

        public ActionResult DeleteStudent(string cin)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            sc.DeleteStudent(cin);
            return GetStudents();
        }
    }
}