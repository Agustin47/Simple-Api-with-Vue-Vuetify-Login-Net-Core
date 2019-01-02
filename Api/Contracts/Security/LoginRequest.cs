
namespace Contracts.Security
{
    using MediatR;

    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
