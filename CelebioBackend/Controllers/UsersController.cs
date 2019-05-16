using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Celebio;

namespace CelebioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Getuser()
        {
            return _context.user;
        }

        // GET: api/Users/5
        [HttpGet("{username}")]
        public ActionResult GetUser([FromRoute] string Username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
//  var user = await _context.user.FindAsync(username=Username);
            var user = _context.user.Where(p=>p.username==Username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{Username}")]
        public ActionResult PutUser([FromRoute] string Username, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Username != user.username)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(Username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.user.Add(user);
            _context.SaveChanges();

            return CreatedAtAction("GetUser", new { username = user.username }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{Username}")]
//        public ActionResult DeleteUser([FromRoute] string Username)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//
//            var a = _context.user.Find(Username); //Where(p=>p.username==Username);
//            if (a == null)
//            {
//                return NotFound();
//            }
//            else{
//            _context.user.Remove(a);
//            _context.SaveChanges();
//            }
//            return Ok(a);
//        }

        private bool UserExists(string Username)
        {
            return _context.user.Any(e => e.username == Username);
        }
    }
}
