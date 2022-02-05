using AutoMapper;

namespace WebApplication1
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UserForRegistrationDto, AppUser>()
				.ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
		}
	}
}
