using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Agency.Models.DTOs;
using Agency.Models.Entities.Member;
using Agency.Data.Repositories;
using Agency.Utilities;
using Agency.Services.Authentication.UserService;
using Agency.Interfaces;

namespace Agency.Services.Authentication.UserService;
public sealed class UserService : IUserService
{
    private readonly UserRepository _repository;
    private readonly IMapper _mapper;
    public UserService(UserRepository repository, IMapper mapper)
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

        return userEntity;
    }

    public UserDataDTO? GetUser(string? username)
    {
        ArgumentNullException.ThrowIfNull(username);

        return _users.SingleOrDefault(u => u.Username == username);
    }

    public bool IsAuthenticated(string? password, string? passwordHash)
    {
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(passwordHash);

        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }


}