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

        //Get all AppUsers
        // api/users
        //synchronous code
        /*[HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var Users = _context.Users.ToList();
            return Users;
        }*/
        //Asynchronous code - more scalable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var Users = _context.Users.ToListAsync();
            return await Users;
        }

        //Getting a specific user using Id parameter
        // api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int Id)
        {
            var User = _context.Users.FindAsync(Id);
            return await User;
        }
    }
}