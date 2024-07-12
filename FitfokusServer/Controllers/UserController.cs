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

    // comment to see if CD is working OOB

    [HttpGet("{id}")]
    //   [Authorize (Roles ="user, admin, super-admin")  ]
    public async Task<ActionResult<GetUserResponseDTO>> GetUser(int id)
    {
    //  if (!await _userRepository.UsersFound() || !await _userRepository.UserExists(id)){return NotFound("No user with that Id exists");}

          var getUser = await _userRepository.GetUser(new GetUserRequestDTO { Id = id });
        

        var user = new GetUserResponseDTO(); //{ DummyResponse = getUser.UserResponse1 };

      return Ok (user);
    }


    [HttpPost]
    public async Task<ActionResult<GetUserResponseDTO>> createUser(CreateUserRequestDTO createUserRequest)
    {

    //    if (await _userRepository.UserEmailExists(userCreateDTO.Email)) { return BadRequest("Email already exists"); }

    //    var user = _mapper.Map<User>(userCreateDTO);

          var  user =   await _userRepository.CreateUser(createUserRequest);
    
        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }


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