using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Listings.Core.Entities;
using Listings.Core.Logic.Commands;
using Listings.Core.Logic.Handlers;
using Listings.Core.Repositories;
using Moq;
using Tests.Shared;
using Xunit;

namespace Tests.CoreTests
{
    public class GetListingCommandHandlerTests
    {
        [Theory]
        [AutoDomainData]
        public async Task GetListingById_ReturnsListing(
            [Frozen] Mock<IListingRepository> repository,
            Listing listing,
            GetListingCommandHandler sut
        )
        {
            //Arrange
            repository
                .Setup(x =>
                        x.GetListing(It.IsAny<Guid>(), It.IsAny<CancellationToken>()
                    )
                )
                .ReturnsAsync(listing);

            var command = new GetListingCommand
            {
                ListingId = listing.ListingId
            };
            
            //Act
            var response = await sut.Handle(command, CancellationToken.None);

            //Assert
            response.ListingId.Should().Be(listing.ListingId);
        }
    }
}