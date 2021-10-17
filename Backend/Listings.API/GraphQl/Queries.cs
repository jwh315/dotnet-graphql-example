using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotChocolate;
using Listings.API.Models;
using Listings.Core.Logic.Commands;
using MediatR;

namespace Listings.API.GraphQl
{
    public class Queries
    {
        private readonly IMapper _mapper;

        public Queries(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ListingModel> GetListing([Service] IMediator mediator, Guid listingId)
        {
            var listing = await mediator.Send(new GetListingCommand
            {
                ListingId = listingId
            });

            var listingModel = _mapper.Map<ListingModel>(listing);

            return listingModel;
        }

        public async Task<List<ListingModel>> GetListings([Service] IMediator mediator)
        {
            var listings = await mediator.Send(new GetAllListingsCommand());

            var listingModels = _mapper.Map<List<ListingModel>>(listings);

            return listingModels;
        }
    }
}