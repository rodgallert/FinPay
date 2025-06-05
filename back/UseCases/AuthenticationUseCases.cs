using Domain.Interfaces.UseCases;
using Domain.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UseCases;
public class AuthenticationUseCases : IAuthenticationUseCases
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly IConfiguration _configuration;
    private readonly JwtOptions _jwtOptions;
    public AuthenticationUseCases(IHttpContextAccessor httpContext,
            IConfiguration configuration,
            IOptions<JwtOptions> jwtOptions)
    {
        _httpContext = httpContext;
        _configuration = configuration;
        _jwtOptions = jwtOptions.Value;
    }
    public string GenerateToken(string email, 
            Guid publicId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.UserData, publicId.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public Guid GetUserIdFromToken()
    {
        var user = _httpContext.HttpContext?.User;
        if (user == null || !user.Identity.IsAuthenticated)
            return Guid.Empty;

        var publicIdClaim = user.FindFirst(ClaimTypes.UserData);
        
        return publicIdClaim != null ? Guid.Parse(publicIdClaim.Value) : Guid.Empty;
    }
}
