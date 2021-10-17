using System;
using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using Listings.API.Models;
using Listings.Core.Entities;
using Listings.Core.Logic.Commands;
using MediatR;

namespace Listings.API.GraphQl
{
    public class Mutations
    {
        private readonly IMapper _mapper;

        public Mutations(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ListingModel> CreateListing([Service] IMediator mediator, ListingModel input)
        {
            var listing = await mediator.Send(new CreateListingCommand
            {
                Listing = _mapper.Map<Listing>(input)
            });
            
            var listingModel = _mapper.Map<ListingModel>(listing);

            return listingModel;
        }

        public async Task<bool> DeleteListing([Service] IMediator mediator, Guid listingId)
        {
            return await mediator.Send(new DeleteListingCommand
            {
                ListingId = listingId
            });
        }
    }
}