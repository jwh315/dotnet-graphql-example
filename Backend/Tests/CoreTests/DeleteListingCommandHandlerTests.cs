using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Listings.Core.Logic.Commands;
using Listings.Core.Logic.Handlers;
using Listings.Core.Repositories;
using Moq;
using Tests.Shared;
using Xunit;

namespace Tests.CoreTests
{
    public class DeleteListingCommandHandlerTests
    {
        [Theory]
        [AutoDomainData]
        public async Task DeleteListingById_ShouldReturn_True(
            [Frozen] Mock<IListingRepository> repository,
            Guid listingId,
            DeleteListingCommandHandler sut
        )
        {
            //Arrange
            repository
                .Setup(x =>
                    x.DeleteListing(It.IsAny<Guid>(), It.IsAny<CancellationToken>()
                    )
                )
                .Returns(Task.FromResult(true));

            var command = new DeleteListingCommand
            {
                ListingId = listingId
            };

            //Act
            var response = await sut.Handle(command, CancellationToken.None);

            //Assert
            response.Should().Be(true);
        }
    }
}