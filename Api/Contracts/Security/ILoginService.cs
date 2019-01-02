

using Contracts.Security.Initializer;

namespace Contracts.Security
{

    public interface ILoginService
    {

        LoginUserResponse LoginUser(LoginUserRequest request);
        InitializerResponse Initializer(InitializerRequest request);
    }
}
