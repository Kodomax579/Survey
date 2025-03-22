using Microsoft.AspNetCore.Mvc;
using Umfrage.DTO;
using Umfrage.Model;
using Umfrage.Services;

namespace Umfrage.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public ActionResult<List<UserDTO>> GetAllUser()
        {
            var users = _userService.AllUser().Select(ToUserDTO).ToList();
            return Ok(users);
        }

        [HttpGet("single")]
        public ActionResult<UserDTO> GetSingleUser(string email, string password)
        {
            var user = _userService.SelectedUser(email, password);
            if (user == null) return NotFound();
            return Ok(ToUserDTO(user));
        }

        [HttpPost("create")]
        public ActionResult<bool> CreateNewUser(CreateUserDTO newUser)
        {
            if (_userService.CreateUser(newUser))
                return Ok(true);
            return BadRequest("User could not be created.");
        }

        [HttpPut("update")]
        public ActionResult<bool> UpdateUser(User updatedUser)
        {
            if (_userService.UpdateUser(updatedUser))
                return Ok(true);
            return BadRequest("User could not be updated.");
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> DeleteUser(int id)
        {
            if (_userService.DeleteUser(id))
                return Ok(true);
            return NotFound("User not found.");
        }

        private UserDTO ToUserDTO(User user)
        {
            return new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Schoolclass = user.Schoolclass
            };
        }
    }
}
