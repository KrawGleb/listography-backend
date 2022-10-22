using AutoMapper;
using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.ViewModels.Identity;
using iLearning.Listography.Application.Requests.Users.Queries.GetMe;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Users.QueryHandlers;

public class GetMeCommandHandler : IRequestHandler<GetMeQuery, Response>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public GetMeCommandHandler(
        UserManager<ApplicationUser> userManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        var user = await GetUserAsync(request.Id!, cancellationToken);
        var me = _mapper.Map<MeViewModel>(user);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = me
        };

    }

    private async Task<ApplicationUser> GetUserAsync(string id, CancellationToken cancellationToken)
    {
        var user = await _userManager
            .Users
            .Include(u => u.Lists!)
                .ThenInclude(l => l.Topic)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken)
       ?? throw new NotFoundException("User not found");

        return user;
    }
}
