using System;
using System.Threading;
using System.Threading.Tasks;
using Listings.Core.Entities;
using Listings.Core.Logic.Commands;
using Listings.Core.Repositories;
using MediatR;

namespace Listings.Core.Logic.Handlers
{
    public class CreateListingCommandHandler: IRequestHandler<CreateListingCommand, Listing>
    {
        private readonly IListingRepository _listingRepository;

        public CreateListingCommandHandler(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }
        
        public async Task<Listing> Handle(CreateListingCommand request, CancellationToken cancellationToken)
        {
            request.Listing.ListingId = Guid.NewGuid();
            request.Listing.Status = ListingStatus.LISTED;

            await _listingRepository.SaveListing(request.Listing, cancellationToken);

            return request.Listing;
        }
    }
}