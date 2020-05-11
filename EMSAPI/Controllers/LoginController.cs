using EMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMSAPI.Controllers
{
    public class LoginController : Controller
    {
     
        // GET: Login
        public ActionResult Index()
        {
            if (Session["USERID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        // Get method for register
        public ActionResult Register()
        {
            return View();
        }


        //post method for register, sending data using post method.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using(EmsContext em = new EmsContext())
                {
                    em.Users.Add(user);
                    em.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "registration unsuccessfull");
            }
            return View(user);
        }

        //get method for login
        public ActionResult Login()
        {
            return View();
        }

        //post method for login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
           
                using (EmsContext em = new EmsContext())
                {
                    var lobj = em.Users.Where(m => m.EMAIL.Equals(user.EMAIL) && m.USERPASSWORD.Equals(user.USERPASSWORD)).FirstOrDefault();
                    if (lobj != null)
                    {
                        Session["USERID"] = lobj.USERID.ToString();
                        Session["USERNAME"] = lobj.USERNAME.ToString();
                        Session["USERTYPE"] = lobj.USERTYPE.ToString();
                        return RedirectToAction("Index");
                    }
                else
                {
                    ModelState.AddModelError("","Invalid Credintials");
                }
                }

           
            return View(user);

        }
    }
}