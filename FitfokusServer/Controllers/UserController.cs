using FitfokusServer.Interfaces;
using FitfokusServer.Models.DTOs.Requests;
using FitfokusServer.Models.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitfokusServer.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;


    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }



    [HttpGet("{id}")]
    //   [Authorize (Roles ="user, admin, super-admin")  ]
    public async Task<ActionResult<UserResponseDTO>> GetUser(int id)
    {
      if (!await _userRepository.UsersFound() || !await _userRepository.UserExists(id)){return NotFound("No user with that Id exists");}

          var getUser = await _userRepository.GetUser(id);

        var user = new UserResponseDTO();

      return Ok (user);
    }


    //[HttpPost]
    //public async Task<ActionResult<UserResponseDTO>> createUser(UserCreateDTO userCreateDTO)
    //{

    //    if (await _userRepository.UserEmailExists(userCreateDTO.Email)) { return BadRequest("Email already exists"); }

    //    var user = _mapper.Map<User>(userCreateDTO);

    //    await _userRepository.CreateUser(user);

    //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
    //}


    [HttpDelete("{id}")]
    [Authorize(Roles = "super-admin")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (!await _userRepository.UsersFound())
        {
            return Problem("No users found in the database");
        }
        var deleteUser = await _userRepository.DeleteUser(id);

        if (!deleteUser)
        {
            return NotFound();
        }
        return NoContent();

    }

}