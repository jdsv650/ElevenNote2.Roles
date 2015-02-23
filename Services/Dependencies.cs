using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Services
{
    public class Dependencies 
    {
        public static ElevenNoteDataContext DataContext
        {
            get { return new ElevenNoteDataContext(); }
        }

    }
}
