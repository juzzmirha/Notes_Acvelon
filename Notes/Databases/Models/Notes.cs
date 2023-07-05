using System;
using NotesDB.DTO;
namespace NotesDB.Models
{
    public class Notes
    {
        public int id { get; set; }
        public string text { get; set; }
        public DateTime datetime { get; set; }

        public int UserId { get; set; } // Внешний ключ
        public Users User { get; set; } // Навигационное свойство
    }
}
