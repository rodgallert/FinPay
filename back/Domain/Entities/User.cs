using Domain.DTO;

namespace Domain.Entities;
public class User : BaseEntity
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }

    public string? UtmCampaign { get; set; }
    public string? UtmSource { get; set; }
    public string? UtmMedium { get; set; }
    public string? UtmContent { get; set; }
    public string? UtmTerm { get; set; }

    public static User FromCreate(UserDto request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Salt = Shared.Utils.GenerateSalt(),
            UtmCampaign = request.UtmCampaign,
            UtmSource = request.UtmSource,
            UtmMedium = request.UtmMedium,
            UtmContent = request.UtmContent,
            UtmTerm = request.UtmTerm
        };

        user.Password = Shared.Utils.EncryptBcrpypt(request.Password, user.Salt);

        return user;
    }

    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PublicId = user.PublicId
        };
    }
}
