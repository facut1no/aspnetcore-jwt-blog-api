using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PostCommentAPI.Models;

namespace PostCommentAPI.Auth;

public sealed class TokenProvider(IOptions<JwtSettings> options) : ITokenProvider
{
  private readonly JwtSettings _jwtSettings = options.Value;
  public string Create(User user)
  {
    var securityKey = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(_jwtSettings.Key)
    );

    var credentials = new SigningCredentials(
      securityKey,
      SecurityAlgorithms.HmacSha256
    );

    var claims = new[]
    {
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.NameId, user.Username),
      new Claim(JwtRegisteredClaimNames.Email, user.Username),
    };

    var token = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      claims: claims,
      expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
      signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}