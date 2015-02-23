using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DataAccess
{
    public class ElevenNoteDataContext : DbContext
    {
        #region Constructor

        public ElevenNoteDataContext() : base("DefaultConnection")
        {

        }
        #endregion

        #region

        public DbSet<Note> Notes { get; set; }

        #endregion
    }
}
