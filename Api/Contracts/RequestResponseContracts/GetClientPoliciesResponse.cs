
namespace Contracts.RequestResponseContracts
{
    using ContractEntities;
    using System.Collections.Generic;

    public class GetClientPoliciesResponse
    {

        public List<Policy> Policies { get; set; }

    }
}
