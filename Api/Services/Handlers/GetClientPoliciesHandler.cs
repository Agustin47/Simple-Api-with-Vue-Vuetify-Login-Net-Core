
namespace Services.Handlers
{
    using Context;
    using Contracts.RequestResponseContracts;
    using Contract = Contracts.ContractEntities;
    using Domain;
    using MediatR;
    using Services.Helpers;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class GetClientPoliciesHandler : IRequestHandler<GetClientPoliciesRequest, GetClientPoliciesResponse>
    {

        #region Properties

        private readonly LivyDbContext _context;

        public GetClientPoliciesHandler(LivyDbContext livyDbContext)
        {
            _context = livyDbContext;
        }

        #endregion  

        public Task<GetClientPoliciesResponse> Handle(GetClientPoliciesRequest request, CancellationToken cancellationToken)
            => Task.Run(() =>
            {
                var predicate = PredicateBuilder.True<Policy>();

                if (!string.IsNullOrEmpty(request.UserName))
                    predicate = predicate.And(x => x.Client.Name == request.UserName);

                var response = _context.Policies.Include(p => p.Client).Where(predicate);

                return new GetClientPoliciesResponse
                {
                    Policies = response.Select( x => (Contract.Policy)x ).ToList()
                };
            });
    }
}
