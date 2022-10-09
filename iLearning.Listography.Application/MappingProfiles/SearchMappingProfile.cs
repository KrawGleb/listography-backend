using AutoMapper;
using iLearning.Listography.DataAccess.Models.Common;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.MappingProfiles;

public class SearchMappingProfile : Profile
{
    public SearchMappingProfile()
    {
        CreateMap<ListItem, SearchItem>()
            .ForMember(item => item.Id,
                opt => opt.MapFrom(i => i.Id))
            .ForMember(item => item.Name,
                opt => opt.MapFrom(i => i.Name))
            .ForMember(item => item.List,
                opt => opt.MapFrom(i => i.UserList.Title))
            .ForMember(item => item.Author,
                opt => opt.MapFrom(i => i.UserList.Account.UserName))
            .ForMember(item => item.Tags,
                opt => opt.MapFrom(i => i.Tags));
    }
}
