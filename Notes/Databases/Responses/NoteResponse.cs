using NotesDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesDB.Responses
{
    public class NoteResponse
    {
        public int id { get; set; }
        public string text { get; set; }
        public DateTime datetime { get; set; }

        public int UserId { get; set; } // Внешний ключ
    }
}
