
namespace Contracts.RequestResponseContracts
{
    using MediatR;

    public class GetClientPoliciesRequest : IRequest<GetClientPoliciesResponse>
    {
        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string UserName { get; set; }

    }
}
