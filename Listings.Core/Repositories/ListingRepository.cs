using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Listings.Core.Entities;

namespace Listings.Core.Repositories
{
    public class ListingRepository : IListingRepository
    {
        private readonly IDynamoDBContext _context;

        public ListingRepository(IDynamoDBContext context)
        {
            _context = context;
        }
        
        public async Task<Listing> SaveListing(Listing listing, CancellationToken cancellationToken)
        {
            await _context.SaveAsync(listing, cancellationToken);

            return listing;
        }

        public async Task<Listing> GetListing(Guid listingId, CancellationToken cancellationToken)
        {
            var listing = await _context.LoadAsync<Listing>(listingId, cancellationToken);
            
            return listing;
        }

        public async Task<List<Listing>> GetAllListings(CancellationToken cancellationToken)
        {
            var config = new ScanOperationConfig
            {
                Limit = 100,
            };

            var listings = await _context.FromScanAsync<Listing>(config).GetNextSetAsync(cancellationToken);

            return listings;
        }

        public async Task DeleteListing(Guid listingId, CancellationToken cancellationToken)
        {
            await _context.DeleteAsync<Listing>(listingId, cancellationToken);
        }
    }

    public interface IListingRepository
    {
        Task<Listing> SaveListing(Listing listing, CancellationToken cancellationToken);

        Task<Listing> GetListing(Guid listingId, CancellationToken cancellationToken);

        Task<List<Listing>> GetAllListings(CancellationToken cancellationToken);

        Task DeleteListing(Guid listingId, CancellationToken cancellationToken);
    }
}