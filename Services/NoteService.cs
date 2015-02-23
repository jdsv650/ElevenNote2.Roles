using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NoteService
    {

        public List<NoteListViewModel> GetAll(string requestingUserId)
        {
            using (var context = Dependencies.DataContext)
            {
                //return (from r in context.Notes
                //        where r.ApplicationUserId == requestingUserId
                //        select new NoteListViewModel()
                //        {
                //            DateCreated = r.DateCreated,
                //            DateModified = r.DateModified,
                //            Id = r.NoteId,
                //            Title = r.Title
                //        }).OrderBy(o => o.DateModified).ToList();


                var query = context.Notes.Where(n => n.ApplicationUserId == requestingUserId).Select(n => new NoteListViewModel()
                            {
                                DateCreated = n.DateCreated,
                                DateModified = n.DateModified,
                                Id = n.NoteId,
                                Title = n.Title
                            }).OrderBy(n => n.Title);

                var result = query.ToList();
                return result;
            }
        }


        public bool Create(NoteDetailViewModel model, string requestingUserId)
        {
            using (var context = Dependencies.DataContext)
            {
                context.Notes.Add(new Note()
                {
                    ApplicationUserId = requestingUserId,
                    NoteId = model.Id,
                    Title = model.Title,
                    Contents = model.Content,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                });

                return 1 == context.SaveChanges();

            }
        }

        public NoteDetailViewModel GetNoteById(int id, string requestingUserId)
        {
            using (var context = Dependencies.DataContext)
            {
                var result = context.Notes.Where(n => n.ApplicationUserId == requestingUserId && n.NoteId == id).
                    Select(n => new Models.NoteDetailViewModel { Id = n.NoteId, Title = n.Title, DateCreated = n.DateCreated, DateModified = n.DateModified, Content = n.Contents }).
                    SingleOrDefault();
               return result;
            }
        }
    }
}
