using AutoMapper;
using iLearning.Listography.Application.Models.ViewModels.Identity;
using iLearning.Listography.DataAccess.Models.Identity;

namespace iLearning.Listography.Application.MappingProfiles;

public class UserMappingProfile : Profile
{
	public UserMappingProfile()
	{
		CreateMap<ApplicationUser, MeViewModel>();
	}
}
