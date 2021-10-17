using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace Listings.Core.Entities
{
    [DynamoDBTable("Listings")]
    public class Listing
    {
        [DynamoDBHashKey] public Guid ListingId { get; set; }

        public ListingStatus Status { get; set; }

        public Location Origin { get; set; }

        public Location Destination { get; set; }

        public List<Vehicle> Vehicles { get; set; }
        
    }
}