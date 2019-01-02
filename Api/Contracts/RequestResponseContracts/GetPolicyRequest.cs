
namespace Contracts.RequestResponseContracts
{

    using MediatR;

    public class GetPolicyRequest : IRequest<GetPolicyResponse>
    {
        /// <summary>
        /// Id del usuario.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email de la Policy
        /// </summary>
        public string Email { get; set; }

    }
}
