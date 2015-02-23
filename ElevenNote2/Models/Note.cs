using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote2.Models
{
    public class Note
    {
        [Display(Name = "Note Id")]
        public int NoteId { get; set; }
        [Display(Name = "Application User Id")]
        public string ApplicationUserId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Content")]
        public string Content { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime DateMofified { get; set; }

    }
}
