using System;
using System.Threading.Tasks;
using Discount.API.Infrastructure.Repositories.Interfaces;
using Grpc.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Discount.API
{
    public class DiscountGrpcService : DiscountService.DiscountServiceBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<DiscountGrpcService> _logger;
        private const string _discountCache = "discountCache";

        public DiscountGrpcService(
            IProductRepository productRepository,
            IUserRepository userRepository,
            IMemoryCache memoryCache,
            ILogger<DiscountGrpcService> logger)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public override async Task<DiscountResponse> GetDiscount(DiscountRequest request, ServerCallContext context)
        {
            if (!_memoryCache.TryGetValue
                ($"{_discountCache}_{request.ProductId}_{request.UserId}",
                out Domain.Discount discount))
            {
                DiscountResponse discountResponse = null;

                var product = await _productRepository.GetProductById(Guid.Parse(request.ProductId));
                var user = await _userRepository.GetUserById(Guid.Parse(request.UserId));

                if (product == null || user == null)
                {
                    return discountResponse;
                }

                discount = Domain.Discount
                    .RuleDiscount(product.PriceInCents, user.DateOfBirth);

                _logger.LogInformation(@$"Discount => Pct: {discount.Pct} |
                    ValueInCents: {discount.ValueInCents}");

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(24 - DateTime.Now.Hour));

                _memoryCache.Set(
                    $"{_discountCache}_{request.ProductId}_{request.UserId}",
                    discount,
                    cacheOptions);
            }

            return new DiscountResponse
            {
                Pct = discount.Pct,
                ValueInCents = discount.ValueInCents
            };
        }
    }
}

