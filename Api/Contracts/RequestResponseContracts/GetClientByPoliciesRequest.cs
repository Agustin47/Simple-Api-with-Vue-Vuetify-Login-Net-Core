

namespace Contracts.RequestResponseContracts
{
    using MediatR;

    public class GetClientByPoliciesRequest : IRequest<GetClientByPoliciesResponse>
    {
        
        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string PolicyId { get; set; }

    }
}
