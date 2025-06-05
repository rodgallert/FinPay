using Domain.Entities;

namespace Domain.ViewModels;
public class LoginViewModel
{
    public string Token { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string PublicId { get; set; }

    public static LoginViewModel FromModel(User user, string token)
    {
        return new LoginViewModel
        {
            Token = token,
            Email = user.Email,
            Name = $"{user.FirstName} {user.LastName}",
            PublicId = user.PublicId.ToString()
        };
    }
}
