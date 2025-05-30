namespace Domain.Entities;
public class FinPayFile : BaseEntity
{
    public string PublicLink { get; set; }
    public string FileName { get; set; }
    public string Key { get; set; }
    public string ContentType { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Address { get; set; }
    public string? Complement { get; set; }

    public string UtmCampaign { get; set; }
    public string UtmSource { get; set; }
    public string UtmMedium { get; set; }
    public string UtmContent { get; set; }
    public string UtmTerm { get; set; }

}
