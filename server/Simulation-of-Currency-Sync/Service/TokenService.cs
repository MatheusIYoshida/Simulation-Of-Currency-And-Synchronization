using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Simulation_of_Currency_Sync.DTOs;
using Simulation_of_Currency_Sync.Repository;

namespace Simulation_of_Currency_Sync.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _repository;

    public TokenService(IConfiguration config, IUserRepository repository)
    {
        _config = config;
        _repository = repository;

    }

    public string GenerateTokenJWT(UserDTO userDTO)
    {
        var profileDataBase = _repository.GetProfile(userDTO.Email);
        if (profileDataBase == null || userDTO.Email != profileDataBase.Email ||
            userDTO.Password != profileDataBase.Password)
            return string.Empty;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("Name", profileDataBase.Name),
            new Claim("Email", profileDataBase.Email),
            new Claim("Admin", profileDataBase.Admin.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:ValidIssuer"],
            audience: _config["Jwt:ValidAudience"],
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
