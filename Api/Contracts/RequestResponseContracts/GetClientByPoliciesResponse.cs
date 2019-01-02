
namespace Contracts.RequestResponseContracts
{
    using ContractEntities;
    using System.Collections.Generic;

    public class GetClientByPoliciesResponse
    {
        /// <summary>
        /// Usuarios que pertenecen a la policie del request.
        /// </summary>
        public List<Client> Clients { get; set; }

    }
}
