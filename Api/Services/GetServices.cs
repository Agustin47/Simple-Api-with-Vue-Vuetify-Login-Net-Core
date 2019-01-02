
namespace Services
{
    using Contracts.Services;
    using Contracts.RequestResponseContracts;
    using MediatR;

    public class GetServices : IGetServices
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
        public GetServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        /// <summary>
        /// Obtiene los usuarios por nombre o id.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetClientResponse GetClient(GetClientRequest request)
            => _mediator.Send(request).Result;

            /// <summary>
            /// Obtiene las policies de un usuario.
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
        public GetClientPoliciesResponse GetClientPolicies(GetClientPoliciesRequest request)
            => _mediator.Send(request).Result;

        /// <summary>
        /// Obtiene los usuarios que tengan dicha policie.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetClientByPoliciesResponse GetUserByPolicies(GetClientByPoliciesRequest request)
            => _mediator.Send(request).Result;

    }
}
