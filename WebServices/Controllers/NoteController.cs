using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace WebServices.Controllers
{
    [Authorize]
    public class NoteController : ApiController
    {
        /// <summary>
        /// Gets all notes for current user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNotes")]
        public List<NoteListViewModel> GetNotes()    // GetNotes and GetNote(int id) Fiddler tried to call GetNote(id)
        {
            var service = new NoteService();
            var userId = User.Identity.GetUserId();
            return service.GetAll(userId);
        }

        /// <summary>
        /// Get the note specified by id for the current user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNote")]
        public NoteDetailViewModel GetNote(int id)
        {
            var service = new NoteService();
            var userId = User.Identity.GetUserId();
            return service.GetNoteById(id, userId);
        }


    }
}
