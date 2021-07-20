using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteShare.WebApi
{
    public class Note
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Course { get; set; }
        

    }
}
