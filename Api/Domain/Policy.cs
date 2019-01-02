

namespace Domain
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

    }
}
