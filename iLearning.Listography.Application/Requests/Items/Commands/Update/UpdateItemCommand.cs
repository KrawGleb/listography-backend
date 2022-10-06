﻿using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Common.Interfaces;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;

namespace iLearning.Listography.Application.Requests.Items.Commands.Update;

public class UpdateItemCommand : IRequest<Response>, IProtectedItemRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<ListTag>? Tags { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
}
