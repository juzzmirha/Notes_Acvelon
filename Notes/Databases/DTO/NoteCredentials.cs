using NotesDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NotesDB.DTO
{
    public class NoteCredentials
    {
        public int id { get; set; }
        public string text { get; set; }
        public DateTime datetime { get; set; }
        public int UserId { get; set; } // Внешний ключ

    }
}
