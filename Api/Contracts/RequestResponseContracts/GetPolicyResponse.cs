
namespace Contracts.RequestResponseContracts
{
    using ContractEntities;
    using System.Collections.Generic;

    public class GetPolicyResponse
    {

        public List<Policy> Policies { get; set; }

    }
}
