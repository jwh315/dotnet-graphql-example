using System.Collections.Generic;
using Listings.Core.Entities;
using MediatR;

namespace Listings.Core.Logic.Commands
{
    public class GetAllListingsCommand : IRequest<List<Listing>>
    {
        
    }
}