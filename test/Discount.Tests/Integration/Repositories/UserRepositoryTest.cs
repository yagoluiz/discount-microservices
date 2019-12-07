using Discount.API.Infrastructure.Context;
using Discount.API.Infrastructure.Entities;
using Discount.API.Infrastructure.Repositories;
using Discount.Tests.Configurations;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Discount.Tests.Integration.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public async Task GetUserById_NotNullTest()
        {
            var configuration = SettingsConfiguration.GetConfigurationRoot;
            var context = new DiscountContext(configuration);
            var repository = new UserRepository(context);

            var userId = Guid.Parse("9a2aaed6-38f8-4f31-9a90-751f78543ae7");
            var repositoryMethod = await repository.GetUserById(userId);

            var repositoryValue = Assert.IsType<User>(repositoryMethod);

            Assert.NotNull(repositoryValue);
        }

        [Fact]
        public async Task GetUserById_NullTest()
        {
            var configuration = SettingsConfiguration.GetConfigurationRoot;
            var context = new DiscountContext(configuration);
            var repository = new UserRepository(context);

            var userId = Guid.NewGuid();
            var repositoryMethod = await repository.GetUserById(userId);

            Assert.Null(repositoryMethod);
        }
    }
}
