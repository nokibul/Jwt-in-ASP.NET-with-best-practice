using AutoMapper;
using Agency.Models.DTOs;
using Agency.Models.Entities.Agency;
using Agency.Models.Entities.Member;

namespace Agency.Models.MappingProfile;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAgencyRequestDTO, AgencyEntity>();
        CreateMap<UserDataDTO, MemberEntity>().ReverseMap();
    }
}
