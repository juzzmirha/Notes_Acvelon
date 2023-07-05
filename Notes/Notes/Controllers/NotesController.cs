using Microsoft.AspNetCore.Mvc;
using NotesDB;
using NotesDB.DTO;
using NotesDB.Models;
using System;

namespace Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesDBContext _dbContext;

        public NotesController(NotesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Контроллер для создание заметок
        [HttpPost("CreateNote")]
        public IActionResult Create([FromBody] NoteCredentials note)
        {
            note.datetime = note.datetime.ToUniversalTime();

            _dbContext.notecredentials.Add(note);
            _dbContext.SaveChanges();

            return Ok(new { message = "Note created successfully" });
        }

        // Контроллер для редактирование заметок
        [HttpPut("UpdateNote/{id}")]
        public IActionResult Update(int id, [FromBody] NoteCredentials noteDto)
        {
            var existingNote = _dbContext.notecredentials.Find(id);

            if (existingNote == null)
            {
                return NotFound();
            }

            existingNote.text = noteDto.text;
            _dbContext.SaveChanges();

            return Ok(new { message = "Note updated successfully" });
        }

        // Контроллер для удаление заметок
        [HttpDelete("DeleteNote/{id}")]
        public IActionResult Delete(int id)
        {
            
            var note = _dbContext.notecredentials.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            _dbContext.notecredentials.Remove(note);
            _dbContext.SaveChanges();

            return Ok(new { message = "Note deleted successfully" });
        }

        // Контроллер для просмотра заметок
        [HttpGet("GetNoteById/{id}")]
        public IActionResult GetNoteById(int id)
        {
            
            NoteCredentials note = _dbContext.notecredentials.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }


    }
}
