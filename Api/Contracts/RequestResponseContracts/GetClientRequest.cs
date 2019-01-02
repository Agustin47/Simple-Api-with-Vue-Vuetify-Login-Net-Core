
namespace Contracts.RequestResponseContracts
{

    using MediatR;

    public class GetClientRequest : IRequest<GetClientResponse>
    {
        /// <summary>
        /// Id del usuario.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string UserName { get; set; }
    }
}
