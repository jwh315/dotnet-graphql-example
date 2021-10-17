using System;
using MediatR;

namespace Listings.Core.Logic.Commands
{
    public class DeleteListingCommand: IRequest<bool>
    {
        public Guid ListingId { get; set; }
    }
}