using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Listings.Core.Entities;
using Listings.Core.Logic.Commands;
using Listings.Core.Repositories;
using MediatR;

namespace Listings.Core.Logic.Handlers
{
    public class GetAllListingsCommandHandler: IRequestHandler<GetAllListingsCommand, List<Listing>>
    {
        private readonly IListingRepository _listingRepository;
        
        public GetAllListingsCommandHandler(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }
        
        public async Task<List<Listing>> Handle(GetAllListingsCommand request, CancellationToken cancellationToken)
        {
            return await _listingRepository.GetAllListings(cancellationToken);
        }
    }
}