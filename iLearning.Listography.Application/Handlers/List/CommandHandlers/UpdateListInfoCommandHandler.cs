using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.List.Commands.UpdateInfo;
using MediatR;

namespace iLearning.Listography.Application.Handlers.List.CommandHandlers;

public class UpdateListInfoCommandHandler : IRequestHandler<UpdateListInfoCommand, Response>
{
    public async Task<Response> Handle(UpdateListInfoCommand request, CancellationToken cancellationToken)
    {
        return new Response
        {
            Succeeded = true
        };
    }
}

