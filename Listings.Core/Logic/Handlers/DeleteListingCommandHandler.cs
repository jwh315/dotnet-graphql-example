using System.Threading;
using System.Threading.Tasks;
using Listings.Core.Logic.Commands;
using Listings.Core.Repositories;
using MediatR;

namespace Listings.Core.Logic.Handlers
{
    public class DeleteListingCommandHandler: IRequestHandler<DeleteListingCommand, bool>
    {
        private readonly IListingRepository _listingRepository;

        public DeleteListingCommandHandler(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }
        
        public async Task<bool> Handle(DeleteListingCommand request, CancellationToken cancellationToken)
        {
            await _listingRepository.DeleteListing(request.ListingId, cancellationToken);
            
            return true;
        }
    }
}