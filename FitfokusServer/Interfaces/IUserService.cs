
using FitfokusServer.Models.DTOs.Requests;
using FitfokusServer.Models.DTOs.Responses;

namespace FitfokusServer.Interfaces;

public interface IUserService
{
    Task<GetUserResponseDTO> GetUser(GetUserRequestDTO getUserRequest);

    Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO createUserRequestDTO);

}
