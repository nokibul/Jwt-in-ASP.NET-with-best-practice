using Microsoft.Extensions.Options;
using AutoMapper;
using Agency.Models.DTOs;
using Agency.Models.Entities.Member;
using Agency.Data.Repositories;
using Agency.Utilities.Auth;
using Agency.Services.Authentication.User;
using Agency.Interfaces;

namespace Agency.Services.Authentication.User;
public sealed class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<UserDataDTO> RegisterUser(UserRegistrationDTO userRegistrationDTO)
    {
        ArgumentNullException.ThrowIfNull(userRegistrationDTO);
        // register using the repo
        userRegistrationDTO.Password = AuthenticationUtil.HashPassword(userRegistrationDTO.Password);

        var userEntity = _mapper.Map<MemberEntity>(userRegistrationDTO);

        var registeredUser = await _repository.AddAsync(userEntity);

        var userData = _mapper.Map<UserDataDTO>(registeredUser);

        return userData;
    }

    // public UserDataDTO? GetUser(string? username)
    // {
    //     ArgumentNullException.ThrowIfNull(username);

    //     return _users.SingleOrDefault(u => u.Username == username);
    // }

    public bool IsAuthenticated(string? password, string? passwordHash)
    {
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(passwordHash);

        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }



}