using AutoMapper;
using iLearning.Listography.Application.Models.Common.List;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.MappingProfiles;

public class CustomFieldMappingProfile : Profile
{
	public CustomFieldMappingProfile()
	{
		CreateMap<CustomFieldModel, CustomField>();
	}
}
