
using FitfokusServer.Models.DTOs.Responses;

namespace FitfokusServer.Interfaces;

public interface IUserService
{
    Task<UserResponseDTO> GetUserDTO(int id);
}
