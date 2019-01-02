

namespace Services.Handlers
{
    using Context;
    using Domain;
    using Contract = Contracts.ContractEntities;
    using Contracts.RequestResponseContracts;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Services.Helpers;

    public class GetPolicyHanlder : IRequestHandler<GetPolicyRequest, GetPolicyResponse>
    {
        #region Properties

        private readonly LivyDbContext _context;

        public GetPolicyHanlder(LivyDbContext livyDbContext )
        {
            _context = livyDbContext;
        }

        #endregion  

        public Task<GetPolicyResponse> Handle(GetPolicyRequest request, CancellationToken cancellationToken)
            => Task.Run(() =>
            {

                var predicate = PredicateBuilder.True<Policy>();

                if (!string.IsNullOrEmpty(request.Id))
                    predicate = predicate.And(x => x.Id == request.Id);

                if (!string.IsNullOrEmpty(request.Email))
                    predicate = predicate.And(x => x.Email == request.Email);

                return new GetPolicyResponse
                {
                    Policies = _context.Policies.Where(predicate).Select(x => (Contract.Policy) x).ToList()
                };
            });
    }
}