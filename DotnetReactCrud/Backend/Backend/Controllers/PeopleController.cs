using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    //this api route can also be hardcoded like [Route("api/people")] 
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        //All the endpoints
        // POST /api/people {body}
        // GET /api/people
        // GET /api/people/2
        // PUT /api/people/2 {body}
        // DELETE /api/people/2
        private readonly AppDbContext _context;

        // In this context is the database connection
        //setter injection which is the part of dependency injection
        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost] //Post /api/people
        public async Task<IActionResult> AddPerson(Person person)
        {
            try
            {
                // At this points of time data is added to the context(context is like a cached data in the memory) but its not added to the database
                _context.People.Add(person);
                //saving the changes to the database
                await _context.SaveChangesAsync();
                return Ok(person); // this will return 200 ok status code + person object in the body

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            ; // 500 internal server error + message in the body response body
        }

        [HttpGet] //GET /api/people
        public async Task<IActionResult> GetPeople(Person person)
        {
            try
            {
                // At this points of time data is added to the context(context is like a cached data in the memory) but its not added to the database
                var people = await _context.People.ToListAsync();
                //if we want to select only certain people
                // var people = await _context.People.select(c => new {
                // c.id, c.firstName, c.lastName
                // }).ToListAsync();

                //saving the changes to the database
                return Ok(person); // this will return 200 ok status code + person object in the body

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           ; // 500 internal server error + message in the body response body
        }
    }


}
