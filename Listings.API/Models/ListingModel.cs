using System;
using System.Collections.Generic;

namespace Listings.API.Models
{
    public class ListingModel
    {
        public Guid? ListingId { get; set; }

        public ListingStatusModel? Status { get; set; }

        public LocationModel Origin { get; set; }

        public LocationModel Destination { get; set; }

        public List<VehicleModel> Vehicles { get; set; }
    }
}