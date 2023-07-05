using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesDB;
using NotesDB.DTO;
using NotesDB.Models;
using NotesDB.Responses;

namespace Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly NotesDBContext _dbContext;

        public LoginController(NotesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Login([FromBody] usercredentials usercredentials)
        {
            try
            {
                // Сохранение данных в базе данных
                _dbContext.usercredentials.Add(usercredentials);
                _dbContext.SaveChanges();

                return Ok(new { message = "User created successfully" });
            }
            catch (DbUpdateException ex)
            {
                // Просмотр внутреннего исключения для получения подробностей об ошибке
                Exception innerException = ex.InnerException;
                string errorMessage = innerException?.Message;

                

               
                return BadRequest(new { message = "Error occurred while saving user credentials", error = errorMessage });
            }

        }

        

    }
}
