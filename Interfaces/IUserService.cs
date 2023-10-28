using Microsoft.AspNetCore.Mvc;
using Agency.Models.DTOs;

namespace Agency.Interfaces;

public interface IUserService
{
    public Task<UserDataDTO> RegisterUser(UserRegistrationDTO userRegistrationData);
    // public Task<UserDataDTO> GetUserByUserName(string username);
    public bool IsAuthenticated(string? password, string? passwordHash);
}