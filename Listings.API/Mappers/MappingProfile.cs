using AutoMapper;
using Listings.API.Models;
using Listings.Core.Entities;

namespace Listings.API.Mappers
{
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<ListingModel, Listing>();
            CreateMap<VehicleModel, Vehicle>();
            CreateMap<LocationModel, Location>();
            CreateMap<ListingStatusModel, ListingStatus>();
            
            CreateMap<Listing, ListingModel>();
            CreateMap<Vehicle, VehicleModel>();
            CreateMap<Location, LocationModel>();
            CreateMap<ListingStatus, ListingStatusModel>();
        }
    }
}