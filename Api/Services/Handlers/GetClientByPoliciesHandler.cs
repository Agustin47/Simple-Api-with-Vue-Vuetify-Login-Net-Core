
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

    public class GetClientByPoliciesHandler : IRequestHandler<GetClientByPoliciesRequest, GetClientByPoliciesResponse>
    {

        #region Properties

        private readonly LivyDbContext _context;

        public GetClientByPoliciesHandler(LivyDbContext livyDbContext)
        {
            _context = livyDbContext;
        }

        #endregion  

        public Task<GetClientByPoliciesResponse> Handle(GetClientByPoliciesRequest request, CancellationToken cancellationToken)
            => Task.Run(() =>
            {
                if (string.IsNullOrEmpty(request.PolicyId))
                    throw new System.Exception("GetUserByPolicies no puede resolverse ya que el request está vacío");

                var predicate = PredicateBuilder.True<Policy>();

                predicate = predicate.And(x => x.Id == request.PolicyId);

                return new GetClientByPoliciesResponse
                {
                    Clients = _context.Policies.Where(predicate)
                                .Select( x => (Contract.Client) x.Client).ToList()
                };
            });
    }
}
