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
    public class CreateListingCommandHandlerTests
    {
        [Theory]
        [AutoDomainData]
        public async Task CreateListing_ShouldSetListingId(
            [Frozen] Mock<IListingRepository> repository,
            Listing listing,
            CreateListingCommandHandler sut
        )
        {
            //Arrange
            listing.ListingId = Guid.Empty;

            repository
                .Setup(x =>
                        x.SaveListing(listing, It.IsAny<CancellationToken>()
                    )
                )
                .ReturnsAsync(listing);

            var command = new CreateListingCommand
            {
                Listing = listing
            };

            //Act
            var response = await sut.Handle(command, CancellationToken.None);

            //Assert
            response.ListingId.Should().NotBe(Guid.Empty);
        }
    }
}