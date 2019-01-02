

namespace Contracts.ContractEntities
{
    using System;

    public class Policy
    {

        public string Id { get; set; }

        public double AmountInsured { get; set; }

        public string Email { get; set; }

        public DateTime InceptionDate { get; set; }

        public bool InstallmentPayment { get; set; }

        public Client Client { get; set; }


        public static implicit operator Policy(Domain.Policy domain)
        {
            if (domain == null) return null;
            return new Policy
            {
                Id  = domain.Id,
                AmountInsured = domain.AmountInsured,
                Client = domain.Client,
                Email = domain.Email,
                InceptionDate = domain.InceptionDate,
                InstallmentPayment = domain.InstallmentPayment
            };
        }

        public static implicit operator Domain.Policy(Policy contract)
        {
            if (contract == null) return null;
            return new Domain.Policy
            {
                Id = contract.Id,
                AmountInsured = contract.AmountInsured,
                Client = contract.Client,
                Email = contract.Email,
                InceptionDate = contract.InceptionDate,
                InstallmentPayment = contract.InstallmentPayment
            };
        }
    }
}
