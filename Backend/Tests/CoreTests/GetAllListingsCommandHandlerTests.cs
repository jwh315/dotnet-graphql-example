using System;
using System.Collections.Generic;
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
    public class GetAllListingsCommandHandlerTests
    {
        [Theory]
        [AutoDomainData]
        public async Task GetAllListings_ReturnsMultipleListings(
            [Frozen] Mock<IListingRepository> repository,
            List<Listing> listings,
            GetAllListingsCommandHandler sut
        )
        {
            //Arrange
            repository
                .Setup(x =>
                    x.GetAllListings(It.IsAny<CancellationToken>()
                    )
                )
                .ReturnsAsync(listings);

            var command = new GetAllListingsCommand();

            //Act
            var response = await sut.Handle(command, CancellationToken.None);

            //Assert
            response.Should().BeEquivalentTo(listings);
        }
    }
}