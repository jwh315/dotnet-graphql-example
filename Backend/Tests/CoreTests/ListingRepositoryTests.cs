using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using AutoFixture.Xunit2;
using FluentAssertions;
using Listings.Core.Entities;
using Listings.Core.Repositories;
using Moq;
using Tests.Shared;
using Xunit;

namespace Tests.CoreTests
{
    public class ListingRepositoryTests
    {
        [Theory]
        [AutoDomainData]
        public async Task GetListingById_ShouldReturnListing(
            [Frozen] Mock<IDynamoDBContext> context,
            ListingRepository sut,
            Listing listing
        )
        {
            //Arrange
            context
                .Setup(x => x.LoadAsync<Listing>(listing.ListingId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(listing);

            //Act
            var response = await sut.GetListing(listing.ListingId, CancellationToken.None);

            //Assert
            response.ListingId.Should().Be(listing.ListingId);
        }
    }
}