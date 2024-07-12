using FitfokusServer.DataBase;
using FitfokusServer.Interfaces;
using FitfokusServer.Models.DomainObjects;
using FitfokusServer.Models.DTOs.Requests;
using FitfokusServer.Models.DTOs.Responses;
using Microsoft.EntityFrameworkCore;

namespace FitfokusServer.Repositories;


public class UserRepository: IUserRepository
    {

    private readonly FitFokusDB _fitFokusDb;

    public UserRepository(FitFokusDB dbContext)
    {
        _fitFokusDb = dbContext;
    }

    public async Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO createUser)
    {
  
        var existingUser = await _fitFokusDb.Users.FirstOrDefaultAsync(user => user.GoogleId == createUser.GoogleId && user.Email == createUser.Email);

        if (existingUser != null)
        {
            throw new InvalidOperationException("User already exists.");
        }

        var user = new User
        {
            GoogleId = createUser.GoogleId,
            Name = createUser.Name,
            Email = createUser.Email,
            Verified = createUser.Verified
        };

        await _fitFokusDb.Users.AddAsync(user);
        await _fitFokusDb.SaveChangesAsync();

        return new CreateUserResponseDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Verified = user.Verified
        };
    }

    public async Task<bool> DeleteUser(int UserId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<GetUserResponseDTO> GetUser(GetUserRequestDTO getUser)
    {
       var user = await _fitFokusDb.Users.FirstOrDefaultAsync(x => x.Id == getUser.Id);
        if (user == null)
        {
            // Hantera fallet där användaren inte hittas, t.ex. genom att returnera null eller kasta ett undantag
            throw new InvalidOperationException("User not found.");
        }

        return new GetUserResponseDTO { Id = user.Id, Email= user.Email, Name= user.Name }; 
    }

    public  Task<bool> Save()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserEmailExists(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UsersFound()
    {
        throw new NotImplementedException();
    }
}
