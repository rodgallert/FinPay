namespace Domain.DTO;
public class UserDto
{
    public Guid PublicId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }

    public string? UtmCampaign { get; set; }
    public string? UtmSource { get; set; }
    public string? UtmMedium { get; set; }
    public string? UtmContent { get; set; }
    public string? UtmTerm { get; set; }
}
