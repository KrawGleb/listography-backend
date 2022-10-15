namespace iLearning.Listography.Application.Models.Common.Identity;

public class AccountModel
{
    public string? Username { get; set; }
    public bool Blocked { get; set; }
    public bool IsAdmin { get; set; }
}
