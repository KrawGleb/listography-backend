using AutoMapper;
using iLearning.Listography.Application.Models.Common;
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
    }
}
