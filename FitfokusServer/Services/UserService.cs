using System.Linq.Expressions;
using FitfokusServer.Interfaces;
using FitfokusServer.Models.DTOs.Requests;
using FitfokusServer.Models.DTOs.Responses;


namespace FitfokusServer.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO createUserRequestDTO)
    {

        if (createUserRequestDTO == null)
        {
            throw new ArgumentNullException(nameof(createUserRequestDTO));
        }


        throw new NotImplementedException();
    }


    public async Task<GetUserResponseDTO> GetUser(GetUserRequestDTO getUserRequest)
    {
        try
        {
            if (getUserRequest == null)
            {
                throw new ArgumentNullException(nameof(getUserRequest));
            }


            return await _userRepository.GetUser(getUserRequest);
        }
        catch (InvalidOperationException ex)
        {

            // Hantera specifika undantag om nödvändigt
            //just nu ör det mappad till 400
            throw;
        }
        catch (Exception ex) {
            //Catch all för ej speciifka undantag
            throw new ApplicationException("jahopp... det här gick ju inte alls", ex);
        }

    }
}

