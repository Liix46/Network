using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Network.Application.Common.Interfaces;
using Network.Domain.Models;
using Network.Infrastructure.Options;

namespace Network.Infrastructure.Identity;

public class TokenService : ITokenService
{
    private readonly AuthOptions _authenticationOptions;
    
    public TokenService(IOptions<AuthOptions> authenticationOptions)
    {
        _authenticationOptions = authenticationOptions.Value;
    }
    public string GenerateAccessToken(User user)
    {
        var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(),
            SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>{ 
            new Claim(JwtRegisteredClaimNames.Email, user.Email),        
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName), };   
        
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _authenticationOptions.Issuer,
            audience: _authenticationOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: signinCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

        return encodedToken;

    }
}
/*
 public string CreateToken(User user){   
  var claims = new List<Claim>{ 
  new Claim(JwtRegisteredClaimNames.Email, user.Email),        
  new Claim(JwtRegisteredClaimNames.GivenName, user.UserName), };    
  var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);   
   var tokenDescriptor = new SecurityTokenDescriptor{  
         Subject = new ClaimsIdentity(claims),
         Expires = DateTime.Now.AddDays(7),        
         SigningCredentials = creds,        
         Issuer = _config["Token:Issuer"]    };   
         var tokenHandler = new JwtSecurityTokenHandler();   
         var token = tokenHandler.CreateToken(tokenDescriptor);    
         return tokenHandler.WriteToken(token);}
 */