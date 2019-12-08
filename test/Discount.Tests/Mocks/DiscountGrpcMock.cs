using Bogus;
using Discount.API;

namespace Discount.Tests.Mocks
{
    public static class DiscountGrpcMock
    {
        public static Faker<DiscountRequest> DiscountRequest =>
            new Faker<DiscountRequest>()
             .RuleFor(x => x.ProductId, f => f.Random.Guid().ToString())
             .RuleFor(x => x.UserId, f => f.Random.Guid().ToString());
    }
}
