using CsvHelper;
using CsvHelper.Configuration;
using iLearning.Listography.Application.Common.Exceptions;
using iLearning.Listography.Application.Models.Responses;
using iLearning.Listography.Application.Requests.Lists.Queries.Export;
using iLearning.Listography.DataAccess.Interfaces.Repositories;
using iLearning.Listography.DataAccess.Models.Helpers.Extensions;
using iLearning.Listography.DataAccess.Models.List;
using MediatR;
using Nest;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Threading;

namespace iLearning.Listography.Application.Handlers.Lists.QueryHandlers;

public class ExportToCsvQueryHandler : IRequestHandler<ExportToCsvQuery, CommonResponse>
{
    private readonly IListsRepository _listsRepository;

    public ExportToCsvQueryHandler(IListsRepository listsRepository)
    {
        _listsRepository = listsRepository;
    }

    public async Task<CommonResponse> Handle(ExportToCsvQuery request, CancellationToken cancellationToken)
    {
        var fileContent = await GenerateFileContentAsync(request.ListId, cancellationToken);

        return new CommonResponse
        {
            Succeeded = true,
            Body = fileContent
        };
    }

    private async Task<string> GenerateFileContentAsync(int listId, CancellationToken cancellationToken)
    {
        var list = await GetListAsync(listId, cancellationToken);
        return GetFileContent(list);
    }

    private async Task<UserList> GetListAsync(int id, CancellationToken cancellationToken)
    {
        return await _listsRepository.GetByIdAsync(options =>
        {
            options.Id = id;
            options.IncludeItems = true;
            options.IncludeItemTemplate = true;
        }, cancellationToken)
            ?? throw new NotFoundException("List not found.");
    }

    private string GetFileContent(UserList list)
    {
        var stringWriter = new StringWriter();
        TextWriter writer = stringWriter;
        var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        WriteFileContentHeader(csvWriter, list.ItemTemplate!);
        WriteFileContentBody(csvWriter, list.Items!);

        return stringWriter.ToString();
    }

    private void WriteFileContentHeader(CsvWriter csvWriter, ListItemTemplate template)
    {
        csvWriter.WriteField("Name");
        foreach (var column in template.CustomFields!)
        {
            csvWriter.WriteField(column.Name);
        }
        csvWriter.NextRecord();
    }

    private void WriteFileContentBody(CsvWriter csvWriter, IEnumerable<ListItem> items)
    {
        foreach (var item in items)
        {
            csvWriter.WriteField(item.Name);

            foreach (var customField in item.CustomFields!)
            {
                csvWriter.WriteField(customField.GetDisplayedValue());
            }

            csvWriter.NextRecord();
        }
    }
}
