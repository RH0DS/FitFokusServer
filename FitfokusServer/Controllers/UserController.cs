using FitfokusServer.Interfaces;
using FitfokusServer.Models.DTOs.Requests;
using FitfokusServer.Models.DTOs.Responses;
using FitfokusServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitfokusServer.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;


    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpGet("{id}")]
    //   [Authorize (Roles ="user, admin, super-admin")  ]
    public async Task<ActionResult<GetUserResponseDTO>> GetUser(int id)
    {
        try {

            var getUser = await _userService.GetUser(new GetUserRequestDTO { Id = id });



            return Ok(getUser);
            }
        catch (InvalidOperationException ex)
        {
            // Hantera specifika undantag
            return BadRequest(new { message = ex.Message });
        }
        catch (ApplicationException ex)
        {
            // Hantera applikationsspecifika undantag
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Hantera alla andra undantag
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
        }
    }


    [HttpPost]
    public async Task<ActionResult<GetUserResponseDTO>> createUser(CreateUserRequestDTO createUserRequest)
    {

    //    if (await _userRepository.UserEmailExists(userCreateDTO.Email)) { return BadRequest("Email already exists"); }

    //    var user = _mapper.Map<User>(userCreateDTO);

          var  user =   await _userService.CreateUser(createUserRequest);
    
        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }


    //[HttpDelete("{id}")]
    //[Authorize(Roles = "super-admin")]
    //public async Task<IActionResult> DeleteUser(int id)
    //{
    //    if (!await _userRepository.UsersFound())
    //    {
    //        return Problem("No users found in the database");
    //    }
    //    var deleteUser = await _userRepository.DeleteUser(id);

    //    if (!deleteUser)
    //    {
    //        return NotFound();
    //    }
    //    return NoContent();

    //}

}