
namespace Services.Handlers
{
    using Context;
    using MediatR;
    using Contracts.Security;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System;
    using Microsoft.Extensions.Configuration;
    using System.Security.Claims;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.EntityFrameworkCore;

    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {

        #region Properties

        private readonly LivyDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginUserHandler(LivyDbContext livyDbContext, IConfiguration configuration)
        {
            _context = livyDbContext;
            _configuration = configuration;
        }

        #endregion  

        public Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
            => Task.Run(() =>
            {
                var user = _context.Users.Include(x => x.Role).
                    FirstOrDefault(x => x.UserName == request.UserName
                                    && x.Avariable);

                if (user == null)
                    return new LoginUserResponse { isValid = false };

                if(!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return new LoginUserResponse { isValid = false };
                }

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserName),
                        new Claim(ClaimTypes.Email, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role.Id),
                        new Claim("idUsuario", user.UserName),
                        new Claim("rol", user.Role.Id)
                    };

                return new LoginUserResponse
                {
                    Token = GenerateToken(claims),
                    isValid = true
                };
            });

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passswordSalt))
            {
                var pswHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHash).SequenceEqual(
                    new ReadOnlySpan<byte>(pswHash));
            }
        }

        private string GenerateToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: creds,
                claims: claims
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
