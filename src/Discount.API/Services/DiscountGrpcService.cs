using System.Threading.Tasks;
using Discount.API.Infrastructure.Repositories.Interfaces;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Discount.API
{
    public class DiscountGrpcService : DiscountService.DiscountServiceBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<DiscountGrpcService> _logger;

        public DiscountGrpcService(
            IProductRepository productRepository,
            IUserRepository userRepository,
            ILogger<DiscountGrpcService> logger)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public override async Task<DiscountResponse> GetDiscount(DiscountRequest request, ServerCallContext context)
        {
            DiscountResponse discountResponse = null;

            var product = await _productRepository.GetProductById(request.ProductId);
            var user = await _userRepository.GetUserById(request.UserId);

            if (product == null || user == null)
            {
                return discountResponse;
            }

            var discount = new Domain.Discount()
                .RuleDiscount(product.PriceInCents, user.DateOfBirth);

            _logger.LogInformation($"Discount => Pct: {discount.Pct} | ValueInCents: {discount.ValueInCents}");

            return new DiscountResponse
            {
                Pct = discount.Pct,
                ValueInCents = discount.ValueInCents
            };
        }
    }
}
