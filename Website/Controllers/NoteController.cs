using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace Website.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {

        private Services.NoteService _service = new Services.NoteService();

        public NoteController()
        {


        }

        // GET: Note
        public ActionResult Index()
        {
            var result = _service.GetAll(User.Identity.GetUserId());
            return View(result);
        }
        
        
        [HttpGet]
        [Authorize(Roles="Admin")]
        [ActionName("Add")]
        public ActionResult AddGet()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ActionName("Add")]
        public ActionResult AddPost(NoteDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.Create(model, User.Identity.GetUserId());
                return RedirectToAction("Index");
            }

            return View(model);
        }



    }
}