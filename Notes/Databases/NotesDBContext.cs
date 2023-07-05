using Microsoft.EntityFrameworkCore;
using NotesDB.DTO;
using NotesDB.Models;
namespace NotesDB
{
    public class NotesDBContext : DbContext
    {
        public DbSet<usercredentials> usercredentials { get; set; }
        public DbSet<NoteCredentials> notecredentials { get; set; }

        public NotesDBContext(DbContextOptions<NotesDBContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId);
        }
        

    }
}
