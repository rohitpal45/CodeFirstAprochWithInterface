using RohitDI_Mvc.Models;
using RohitDI_Mvc.RepositoryInterface;
using RohitDI_Mvc.RepositoryServiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RohitDI_Mvc.Controllers
{
    public class HomeController : Controller
    {
        private ISchemeMaster _IRegistration;
        public HomeController()
        {
            _IRegistration = new SchemeMasterServies();
        }
        public ActionResult Index()
        {
            return View(new Registration());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Registration registration,string Command)
        {
            if (!ModelState.IsValid)
            {
                return View(registration);
            }
            else
            {
                if (Command == "Create User")
                {
                    registration.CreatedOn = DateTime.Now;
                    if (_IRegistration.AddUser(registration) > 0)
                    {

                        //this is GetHashCode by rohit pal 

                        TempData["MessageRegistration"] = "Data Saved Successfully!";
                    }
                }
                else if (Command == "Update User")
                {
                    _IRegistration.UpdateUsersReg(registration);
                    TempData["MessageRegistration"] = "Data Saved Successfully!";
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id != null)
                {
                    var userDetailsResponse = _IRegistration.GetSingleRocordID(id);
                    return View("Index",userDetailsResponse);
                }
                else
                {
                    return View("Index");
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult listWisedata()
        {
            try
            {
                var projectdata = _IRegistration.ListofRegisteredUser();
                if (projectdata.Count() > 0)
                {
                    ViewBag.projectdata = projectdata;
                }
                else
                {
                    ViewBag.projectdata = null;
                }
                return View();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        public JsonResult DeleteUser(int? RegistrationID)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(RegistrationID)))
                {
                    return Json("Error", JsonRequestBehavior.AllowGet);
                }
                var data = _IRegistration.RegisterUserDelete(Convert.ToInt32(RegistrationID));
                if (data > 0)
                {
                    return Json(data: true, behavior: JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(data: false, behavior: JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}