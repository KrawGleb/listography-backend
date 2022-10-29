using AutoMapper;
using iLearning.Listography.Application.Models.ViewModels.List;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.MappingProfiles;

public class ListMappingProfile : Profile
{
	public ListMappingProfile()
	{
		CreateMap<UserList, ListViewModel>();
	}
}
