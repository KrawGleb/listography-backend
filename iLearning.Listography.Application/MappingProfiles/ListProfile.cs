﻿using AutoMapper;
using iLearning.Listography.Application.Requests.List.Commands.AddItem;
using iLearning.Listography.Application.Requests.List.Commands.Create;
using iLearning.Listography.Application.Requests.List.Commands.UpdateInfo;
using iLearning.Listography.DataAccess.Models.List;

namespace iLearning.Listography.Application.MappingProfiles;

public class ListProfile : Profile
{
	public ListProfile()
	{
		CreateMap<CreateListCommand, UserList>();
		CreateMap<UpdateListInfoCommand, UserList>();
		CreateMap<AddItemCommand, ListItem>();
	}
}