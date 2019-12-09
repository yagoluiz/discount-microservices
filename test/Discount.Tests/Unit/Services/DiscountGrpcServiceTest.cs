using Discount.API;
using Discount.API.Infrastructure.Entities;
using Discount.API.Infrastructure.Repositories.Interfaces;
using Discount.Tests.Mocks;
using Grpc.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Discount.Tests.Unit.Services
{
    public class DiscountGrpcServiceTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMemoryCache _memoryCacheMock;
        private readonly Mock<ILogger<DiscountGrpcService>> _loggerMock;
        private readonly Mock<ServerCallContext> _serverCallContextmock;

        public DiscountGrpcServiceTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _memoryCacheMock = new MemoryCache(new MemoryCacheOptions());
            _loggerMock = new Mock<ILogger<DiscountGrpcService>>();
            _serverCallContextmock = new Mock<ServerCallContext>();
        }

        [Fact]
        public async Task GetDiscount_ReturnNullProductAndUserTest()
        {
            Product productMock = null;
            User userMock = null;
            var discountRequestMock = DiscountGrpcMock.DiscountRequest.Generate();

            _productRepositoryMock
                .Setup(x => x.GetProductById(Guid.Parse(discountRequestMock.ProductId)))
                .ReturnsAsync(productMock);

            _userRepositoryMock
                .Setup(x => x.GetUserById(Guid.Parse(discountRequestMock.UserId)))
                .ReturnsAsync(userMock);

            var service = new DiscountGrpcService(
                _productRepositoryMock.Object,
                _userRepositoryMock.Object,
                _memoryCacheMock,
                _loggerMock.Object);

            var response = await service.GetDiscount(discountRequestMock,
                _serverCallContextmock.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task GetDiscount_ReturnDiscountNoCacheTest()
        {
            var productMock = ProductMock.Product.Generate();
            var userMock = UserMock.User.Generate();
            var discountRequestMock = DiscountGrpcMock.DiscountRequest.Generate();

            _productRepositoryMock
                .Setup(x => x.GetProductById(Guid.Parse(discountRequestMock.ProductId)))
                .ReturnsAsync(productMock);

            _userRepositoryMock
                .Setup(x => x.GetUserById(Guid.Parse(discountRequestMock.UserId)))
                .ReturnsAsync(userMock);

            var service = new DiscountGrpcService(
                _productRepositoryMock.Object,
                _userRepositoryMock.Object,
                _memoryCacheMock,
                _loggerMock.Object);

            var response = await service.GetDiscount(discountRequestMock,
                _serverCallContextmock.Object);

            var value = Assert.IsType<DiscountResponse>(response);

            Assert.NotNull(value);
        }

        [Fact]
        public async Task GetDiscount_ReturnDiscountCacheTest()
        {
            var productMock = ProductMock.Product.Generate();
            var userMock = UserMock.User.Generate();
            var discountRequestMock = DiscountGrpcMock.DiscountRequest.Generate();

            _productRepositoryMock
                .Setup(x => x.GetProductById(Guid.Parse(discountRequestMock.ProductId)))
                .ReturnsAsync(productMock);

            _userRepositoryMock
                .Setup(x => x.GetUserById(Guid.Parse(discountRequestMock.UserId)))
                .ReturnsAsync(userMock);

            _memoryCacheMock.Set(@$"discountCache_
                {discountRequestMock.ProductId}_
                {discountRequestMock.UserId}",
                new API.Domain.Discount());

            var service = new DiscountGrpcService(
                _productRepositoryMock.Object,
                _userRepositoryMock.Object,
                _memoryCacheMock,
                _loggerMock.Object);

            var response = await service.GetDiscount(discountRequestMock,
                _serverCallContextmock.Object);

            var value = Assert.IsType<DiscountResponse>(response);

            Assert.NotNull(value);
        }
    }
}
