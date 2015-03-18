using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDirectory.Models;
using EmployeeDirectory.Controllers;
using DataLayer.User;

namespace EmployeeDirectory.Controllers
{
    public class UsersController : Controller
    {
        private UsersModel GetUserModelFromSession()
        {
            UsersModel theModel = (UsersModel)Session["Users"];
            if (theModel == null)
            {
                theModel = new UsersModel();
                Session["Users"] = theModel;
            }

            return theModel;
        }

        public ActionResult UserList()
        {
            UsersModel theModel = GetUserModelFromSession();

            ViewData["Users"] = theModel.GetUsers(0);
            return View();
        }

        public ActionResult Users()
        {
            UsersModel theModel = GetUserModelFromSession();
            List<UserBO> users =  theModel.GetUsers(0); 
            return View(users);
        }

        
        public ActionResult Details(int? Id)
        {
            UsersModel theModel = GetUserModelFromSession();
            List<UserBO> users = theModel.GetUsers((int)Id);
            return View(users[0]);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult AddUser(FormCollection form)
        {

            string firstName = form["FirstName"];
            string lastName = form["LastName"];
            string email = form["Email"];
            string password = form["Password"];


            if (string.IsNullOrEmpty(firstName))
            {
                ModelState.AddModelError("FirstName", "First Name is required");
            }

            if (!ModelState.IsValid) return View();

            UserBO user = new UserBO(firstName, lastName, email, password);
            UsersModel theModel = GetUserModelFromSession();
            theModel.AddUser(user);

            return RedirectToAction("Users");
        }

        public ActionResult Edit(int Id)
        {
            UsersModel theModel = GetUserModelFromSession();
            List<UserBO> users = theModel.GetUsers((int)Id);
            return View(users[0]);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Edit(FormCollection form)
        {
            string firstName = form["FirstName"];
            string lastName = form["LastName"];
            string email = form["Email"];
            string password = form["Password"];
            int ID = Convert.ToInt32(form["ID"]);

            if (string.IsNullOrEmpty(firstName))
            {
                ModelState.AddModelError("FirstName", "First Name is required");
            }

            if (!ModelState.IsValid) return View();

            UserBO user = new UserBO(firstName, lastName, email, password);
            user.ID = ID;
            UsersModel theModel = GetUserModelFromSession();
            theModel.Update(user);


            return RedirectToAction("Details", new { id = ID });
        }
         
        public ActionResult DeleteUser(int ID)
        { 
            if (ID < 0)
            {
                ViewData["ERROR"] = "Please provide a valid User ID";
                return View("../Shared/Error");
            }

            UsersModel theModel = GetUserModelFromSession();
            theModel.DeleteUser(ID);

            return RedirectToAction("Users");
        }
    }

}
