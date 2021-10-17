using System.Reflection;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;
using Listings.Core.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Listings.Core
{
    public static class CoreExtensions
    {
        public static void AddCore(this IServiceCollection services)
        {
            var options = new AWSOptions
            {
                DefaultClientConfig =
                {
                    ServiceURL = "http://localhost:4566",
                }
            };
            
            services.AddAWSService<IAmazonDynamoDB>(options);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
            
            services.AddTransient<IListingRepository, ListingRepository>();
            
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}