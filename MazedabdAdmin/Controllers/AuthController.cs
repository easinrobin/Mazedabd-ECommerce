﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MZ.BusinessLayer;
using MZ.Models;
using Vereyon.Web;

namespace MazedabdAdmin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var data = UserManager.GetUserByUserNameNPassword(user.UserName.Trim(), user.Password.Trim());
            if (data != null)
            {
                Session["UserID"] = data.UserId.ToString();
                Session["UserName"] = data.UserName.ToString();
                Session["Name"] = "Site Admin";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                FlashMessage.Danger("Username or Password Incorrect");
            }

            return View(user);
        }
    }
}