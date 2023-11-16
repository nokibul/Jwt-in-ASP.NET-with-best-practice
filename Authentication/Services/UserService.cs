using AutoMapper;
using Agency.Authentication.DTOs;
using Agency.Member.Entities;
using Agency.Authentication.Utils;
using Agency.Authentication.Interfaces;
using Agency.Member.Interfaces;

namespace Agency.Authentication.Services;
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

        userRegistrationDTO.Password = AuthenticationUtil.HashPassword(userRegistrationDTO.Password);

        var userEntity = _mapper.Map<MemberEntity>(userRegistrationDTO);

        var registeredUser = await _repository.AddAsync(userEntity);

        var userData = _mapper.Map<UserDataDTO>(registeredUser);

        return userData;
    }

    public bool IsAuthenticated(string? password, string? passwordHash)
    {
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(passwordHash);

        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

}