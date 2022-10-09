namespace iLearning.Listography.Application.Models.Responses.Identity;

public class LoginResponse: Response
{
    public string? Token { get; set; }
    public bool IsAdmin { get; set; } = false;
}
