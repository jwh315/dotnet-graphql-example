using System.Threading;
using System.Threading.Tasks;
using Listings.Core.Entities;
using Listings.Core.Logic.Commands;
using Listings.Core.Repositories;
using MediatR;

namespace Listings.Core.Logic.Handlers
{
    public class GetListingCommandHandler : IRequestHandler<GetListingCommand, Listing>
    {
        private readonly IListingRepository _listingRepository;
        
        public GetListingCommandHandler(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }
        
        public async Task<Listing> Handle(GetListingCommand request, CancellationToken cancellationToken)
        {
            return await _listingRepository.GetListing(request.ListingId, cancellationToken);
        }
    }
}