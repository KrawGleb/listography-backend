using AutoMapper;
using iLearning.Listography.Application.Models.Common.List;
using iLearning.Listography.Application.Models.Home;
using iLearning.Listography.Application.Requests.Items.Commands.Add;
using iLearning.Listography.Application.Requests.Items.Commands.Update;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.MappingProfiles;

public class ItemsMappingProfile : Profile
{
    public ItemsMappingProfile()
    {
        CreateMap<AddItemCommand, ListItem>();
        CreateMap<UpdateItemCommand, ListItem>();

        CreateMap<ListItem, ItemModel>()
            .ForMember(r => r.TotalLikesCount,
                o => o.MapFrom(s => s.Likes!.Count));

        CreateMap<ListItem, ItemShortDescription>()
            .ForMember(d => d.ListName,
                o => o.MapFrom(i => i.UserList.Title))
            .ForMember(d => d.Author,
                o => o.MapFrom(i => i.UserList.Account.UserName));
    }
}
