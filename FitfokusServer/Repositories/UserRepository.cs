﻿using FitfokusServer.Interfaces;
using FitfokusServer.Models.DomainObjects.Responses;
using FitfokusServer.Models.DTOs.Requests;

namespace FitfokusServer.Repositories;


    public class UserRepository: IUserRepository
    {

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public UserRepository()
    {
        
    }

    public async Task<CreateUserResponse> CreateUser(CreateUserRequestDTO createUser)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUser(int UserId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(int id)
    {
        return  new User();
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
