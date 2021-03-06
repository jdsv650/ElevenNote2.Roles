﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Website.Models;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Website.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        /// <summary>
        /// Get list of roles for current user
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

           var results = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().GetRoles(User.Identity.GetUserId());


            return View(results);
        }


        public ActionResult Add()
        {
            IdentityDbContext idContext = new IdentityDbContext();
            idContext.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = "Admin" }
                                                         , new IdentityRole() { Name = "Lead" });
            idContext.SaveChanges();

            ApplicationDbContext appContext = new ApplicationDbContext();
            ApplicationUser user = appContext.Users.Where(u => u.UserName.Equals("jp@me.com", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            Request.GetOwinContext().GetUserManager<ApplicationUserManager>().AddToRole(user.Id, "Admin");
            appContext.SaveChanges();

            return View();

        }
    }
}