using System;
using Listings.Core.Entities;
using MediatR;

namespace Listings.Core.Logic.Commands
{
    public class GetListingCommand : IRequest<Listing>  
    {
        public Guid ListingId { get; set; }
    }
}