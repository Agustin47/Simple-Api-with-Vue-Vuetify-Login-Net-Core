

namespace Security
{
    using MediatR;
    using Contracts.Security;
    using Contracts.Security.Initializer;

    public class LoginService : ILoginService
    {

        #region Mediator

        /// <summary>
        /// MediatR para injectar los handlers.
        /// </summary>
        public IMediator _mediator;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        public LoginService(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        public LoginUserResponse LoginUser(LoginUserRequest request)
            => _mediator.Send(request).Result;

        public InitializerResponse Initializer(InitializerRequest request)
            => _mediator.Send(request).Result;

    }
}
