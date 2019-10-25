using System;
using Microsoft.AspNetCore.Mvc;
using TestProject.DataAccess;
using TestProject.Entities;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserDal _userDal;

        public UsersController(IUserDal userDal)
        {
            _userDal = userDal;
        }
        
        // GET api/users
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _userDal.GetList();
                return Ok(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return BadRequest();

        }

        // GET api/users/5
        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {

            try
            {
                var user = _userDal.Get(p => p.UserId == userId);

                if (user == null)
                {
                    return NotFound($"There is no user with id = {userId}");
                }
                
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return BadRequest();
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                _userDal.Add(user);
                
                return new StatusCodeResult(201);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return BadRequest();
        }

        // PUT api/users
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                _userDal.Update(user);
                
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            return BadRequest();
        }

        // DELETE api/users
        [HttpDelete("{userId}")]
        public IActionResult Delete(int userId)
        {
            try
            {
                _userDal.Delete(new User { UserId = userId });

                return new StatusCodeResult(204);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);    
            }
            
            return BadRequest();
        }
    }
}