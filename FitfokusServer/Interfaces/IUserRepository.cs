using FitfokusServer.Models.DomainObjects.Responses;
using FitfokusServer.Models.DTOs.Requests;

namespace FitfokusServer.Interfaces;

public interface IUserRepository
    {
    //    Task<UserResponse> Authenicate(string email, string Password);
        Task<IEnumerable<UserResponse>> GetAllUsers();
        Task<UserResponse> GetUser(int id);
        Task<CreateUserResponse> CreateUser(CreateUserRequestDTO createUser);
        Task<bool> DeleteUser(int UserId);
        Task<bool> Save();
        Task<bool> UsersFound();
        Task<bool> UserExists(int id);
        Task<bool> UserEmailExists(string email);

    }
