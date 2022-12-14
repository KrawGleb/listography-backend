using AutoMapper;
using iLearning.Listography.Application.Models.ViewModels.Common.List;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.MappingProfiles;

public class SocialMappingProfile : Profile
{
	public SocialMappingProfile()
	{
        CreateMap<Comment, CommentViewModel>()
            .ForMember(c => c.Content, opt => opt.MapFrom(s => s.Text))
            .ForMember(c => c.From, opt => opt.MapFrom(s => s.ApplicationUser.UserName));
    }
}
