using AutoMapper;
using iLearning.Listography.Application.Requests.Items.Commands.Add;
using iLearning.Listography.Application.Requests.Lists.Commands.Create;
using iLearning.Listography.Application.Requests.Lists.Commands.Update;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.MappingProfiles;

public class ListsMappingProfile : Profile
{
	public ListsMappingProfile()
	{
		CreateMap<CreateListCommand, UserList>();
		CreateMap<UpdateListInfoCommand, UserList>();
	}
}
