using AutoMapper;
using iLearning.Listography.DataAccess.Models.Common;
using iLearning.Listography.DataAccess.Models.Elastic;
using iLearning.Listography.DataAccess.Models.Helpers;
using iLearning.Listography.DataAccess.Models.Helpers.Extensions;
using iLearning.Listography.DataAccess.Models.List;
using System.Text.RegularExpressions;

namespace iLearning.Listography.Application.MappingProfiles;

public class SearchMappingProfile : Profile
{
    public SearchMappingProfile()
    {
        CreateMap<ListTag, Tag>();

        CreateMap<ListItem, SearchItem>()
            .ForMember(item => item.Id,
                opt => opt.MapFrom(i => i.Id))
            .ForMember(item => item.Name,
                opt => opt.MapFrom(i => i.Name))
            .ForMember(item => item.List,
                opt => opt.MapFrom(i => i.UserList.Title))
            .ForMember(item => item.Author,
                opt => opt.MapFrom(i => i.UserList.ApplicationUser.UserName))
            .ForMember(item => item.CustomFieldValues,
                opt => opt.MapFrom(i => i.CustomFields.Select(f => GetCustomFieldValue(f))));
    }

    private object GetCustomFieldValue(CustomField field)
    {
        if (field.Type == CustomFieldType.TextType 
            && field.TextValue is not null)
        {
            return ClearTextFromTags(field.TextValue);
        }

        return field.GetValue();
    }

    private string ClearTextFromTags(string text)
        => Regex.Replace(text, "<.*?>", string.Empty);
}
