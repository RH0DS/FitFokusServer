using FitfokusServer.Models.DomainObjects;
using FitfokusServer.Models.DTOs.Requests;
using FitfokusServer.Models.DTOs.Responses;

namespace FitfokusServer.Interfaces;

public interface IUserRepository
    {
    //    Task<UserResponse> Authenicate(string email, string Password);
        Task<List<User>> GetAllUsers();
        Task<GetUserResponseDTO> GetUser(GetUserRequestDTO getUser);
        Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO createUser);
        Task<bool> DeleteUser(int UserId);
        Task<bool> Save();
        Task<bool> UsersFound();
        Task<bool> UserExists(int id);
        Task<bool> UserEmailExists(string email);

    }
