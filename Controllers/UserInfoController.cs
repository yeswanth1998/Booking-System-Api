using BookingSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {

        private readonly DataContext _context;
        public UserInfoController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserInfo>>> Get()
        {
            return Ok(await _context.users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> Get(Guid id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return BadRequest("User didn't found with this Id");
            }
            return Ok(await _context.users.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<UserInfo>>> AddUser(UserInfo user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<UserInfo>>> UpdateUser(UserInfo request)
        {
            var dbUser = await _context.users.FindAsync(request.Id);
            if(dbUser == null)
            {
                return BadRequest("User didn't found with this Id");
            }
            dbUser.Name = request.Name;
            dbUser.FirstName = request.FirstName;
            dbUser.LastName = request.LastName;
            dbUser.Email = request.Email;
            dbUser.MobileNumber = request.MobileNumber;

            await _context.SaveChangesAsync();

            return Ok(await _context.users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserInfo>>> DeleteUser(Guid id)
        {
            var dbUser = await _context.users.FindAsync(id);
            if(dbUser == null)
            {
                return BadRequest("User Not found");
            }
            _context.users.Remove(dbUser);
            return Ok(await _context.users.ToListAsync());
        }

    }
}
    