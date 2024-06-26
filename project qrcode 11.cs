
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System.IO;
using project11.Controllers;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace project11.Controllers
{
    public class HomeController : Controller
    {
        private MiralDBEntities db = new MiralDBEntities();




        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginA(LOGIN login)
        {
            try
            {
                var data = db.LOGINs.FirstOrDefault(x => x.EMAIL == login.EMAIL && x.PASSWORD == login.PASSWORD);
                if (data != null)
                {
                    return Json(new { success = true, message = "Login successfull" });
                }
                else
                {
                    return Json(new { success = false, message = "Invalid Username or password" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public ActionResult Signup()
        {
            ViewBag.Title = "Signup";
            return View();
        }

        [HttpPost]
        public JsonResult Signup(LOGIN login)
        {
            try
            {
                db.LOGINs.Add(login);
                db.SaveChanges();
                return Json(new { success = true, message = "Signup successful" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

      
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(ADDRESS_BOOK addressBook)
        {
            try
            {
                db.ADDRESS_BOOK.Add(addressBook);
                db.SaveChanges();
                return Json(new { success = true, message = "Data saved successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
