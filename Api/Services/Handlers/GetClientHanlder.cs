

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

    public class GetClientHanlder : IRequestHandler<GetClientRequest, GetClientResponse>
    {
        #region Properties

        private readonly LivyDbContext _context;

        public GetClientHanlder(LivyDbContext livyDbContext )
        {
            _context = livyDbContext;
        }

        #endregion  

        public Task<GetClientResponse> Handle(GetClientRequest request, CancellationToken cancellationToken)
            => Task.Run(() =>
            {

                var predicate = PredicateBuilder.True<Client>();

                if (!string.IsNullOrEmpty(request.Id))
                    predicate = predicate.And(x => x.Id == request.Id);

                if (!string.IsNullOrEmpty(request.UserName))
                    predicate = predicate.And(x => x.Name == request.UserName);

                return new GetClientResponse
                {
                    Clients = _context.Clients.Where(predicate).Select(x => (Contract.Client)x ).ToList()
                };
            });
    }
}