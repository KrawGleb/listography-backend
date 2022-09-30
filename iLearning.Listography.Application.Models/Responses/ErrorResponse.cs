namespace iLearning.Listography.Application.Models.Responses;

public class ErrorResponse : Response
{
    public IEnumerable<string>? Errors { get; set; }
}
