using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NotesDB.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string login { get; set; }
        public string password { get; set; }


        public ICollection<Notes> Notes { get; set; } // Навигационное свойство

    }
}
