using Listings.Core.Entities;
using MediatR;

namespace Listings.Core.Logic.Commands
{
    public class CreateListingCommand: IRequest<Listing>
    {
        public Listing Listing { get; set; }
    }
}