using Discount.API.Infrastructure.Context;
using Discount.API.Infrastructure.Entities;
using Discount.API.Infrastructure.Repositories;
using Discount.Tests.Configurations;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Discount.Tests.Integration.Repositories
{
    public class ProductRepositoryTest
    {
        [Fact]
        public async Task GetProductById_NotNullTest()
        {
            var configuration = SettingsConfiguration.GetConfigurationRoot;
            var context = new DiscountContext(configuration);
            var repository = new ProductRepository(context);

            var productId = Guid.Parse("a0f5e2f7-7d8e-4c7a-bc0e-7cb40d9af91a");
            var repositoryMethod = await repository.GetProductById(productId);

            var repositoryValue = Assert.IsType<Product>(repositoryMethod);

            Assert.NotNull(repositoryValue);
        }

        [Fact]
        public async Task GetProductById_NullTest()
        {
            var configuration = SettingsConfiguration.GetConfigurationRoot;
            var context = new DiscountContext(configuration);
            var repository = new ProductRepository(context);

            var productId = Guid.NewGuid();
            var repositoryMethod = await repository.GetProductById(productId);

            Assert.Null(repositoryMethod);
        }
    }
}
