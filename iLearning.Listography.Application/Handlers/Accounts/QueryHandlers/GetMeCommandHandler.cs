using AutoMapper;
using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Models.ViewModels.Identity;
using iLearning.Listography.Application.Requests.Accounts.Queries.GetMe;
using iLearning.Listography.DataAccess.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iLearning.Listography.Application.Handlers.Accounts.QueryHandlers;

public class GetMeCommandHandler : IRequestHandler<GetMeQuery, Response>
{
    private readonly UserManager<Account> _userManager;
    private readonly IMapper _mapper;

    public GetMeCommandHandler(
        UserManager<Account> userManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        var account = await GetAccountAsync(request.Id!);
        var me = _mapper.Map<MeViewModel>(account);

        return new CommonResponse()
        {
            Succeeded = true,
            Body = me
        };

    }

    private async Task<Account> GetAccountAsync(string id)
    {
        var account = await _userManager
            .Users
            .Include(u => u.Lists!)
                .ThenInclude(l => l.Topic)
            .FirstOrDefaultAsync(u => u.Id == id)
       ?? throw new NotFoundException("Account not found");

        return account;
    }
}
