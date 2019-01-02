
namespace Contracts.ContractEntities
{

    public class Client
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }


        public static implicit operator Client(Domain.Client domain)
        {
            if (domain == null) return null;
            return new Client
            {
                Id = domain.Id,
                Email = domain.Email,
                Name = domain.Name,
                Role = domain.Role
            };
        }

        public static implicit operator Domain.Client(Client contract)
        {
            if (contract == null) return null;
            return new Domain.Client
            {
                Id = contract.Id,
                Email = contract.Email,
                Name = contract.Name,
                Role = contract.Role
            };
        }
    }
}
