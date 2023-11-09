using AutoMapper;
using Agency.Authentication.DTOs;
using Agency.Agency.Entities;
using Agency.Member.Entities;
using Agency.Agency.DTOs;

namespace Agency.Data.MappingProfile;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // from, to
        CreateMap<UserRegistrationDTO, MemberEntity>();
        CreateMap<CreateAgencyRequestDTO, AgencyEntity>();
        CreateMap<MemberEntity, UserDataDTO>();
    }
}
