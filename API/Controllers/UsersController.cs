using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers ()
        {
            return await _context.Users.ToListAsync();

            // sync code below
            // var users = _context.Users.ToList();
            // return users;
            // //or just (for cleaner code)   return _context.Users.ToList();
        } 

        //api/users/id - e.g. 1, 2 or 3
        [HttpGet("{id}")]

        public async Task<ActionResult<AppUser>> GetUser (int id)
        {
            return await _context.Users.FindAsync(id);
            
            //sync code below
            // var user = _context.Users.Find(id);
            // return user;
            // or just   return _context.Users.Find(id);
        }
    }
}