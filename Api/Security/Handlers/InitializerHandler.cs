
namespace Services.Handlers
{
    using Context;
    using MediatR;
    using Contracts.Security.Initializer;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Http;

    public class InitializerHandler : IRequestHandler<InitializerRequest, InitializerResponse>
    {

        #region Properties

        private readonly LivyDbContext _context;

        public InitializerHandler(LivyDbContext livyDbContext)
        {
            _context = livyDbContext;
        }

        #endregion  

        public Task<InitializerResponse> Handle(InitializerRequest request, CancellationToken cancellationToken)
            => Task.Run(() =>
            {

                var clientes = _context.Clients
                                .Where(x=> !_context.Users.Any(y=> x.Email == y.UserName))
                                .ToList();
                var roles = _context.Roles.ToList();

                var newUsers = new List<Domain.User>();

                foreach (var item in clientes)
                {
                    GenerateHashPassword(item.Name, out byte[] passwordHash, out byte[] passwordSalt);
                    var user = new Domain.User
                    {
                        UserName = item.Email,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Avariable = true,
                        Role = roles.First(x=> x.Id == item.Role)
                    };
                    newUsers.Add(user);
                    _context.Users.Add(user);
                }

                _context.SaveChanges();

                return new InitializerResponse
                {
                    Status = StatusCodes.Status200OK,
                    JsonResult = JsonConvert.SerializeObject(newUsers)
                };
            });
        

        private void GenerateHashPassword( string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
