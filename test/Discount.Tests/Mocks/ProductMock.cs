using Bogus;
using Discount.API.Infrastructure.Entities;

namespace Discount.Tests.Mocks
{
    public static class ProductMock
    {
        public static Faker<Product> Product =>
            new Faker<Product>()
             .RuleFor(x => x.Id, f => f.Random.Guid())
             .RuleFor(x => x.PriceInCents, f => f.Random.Int(1, 1000))
             .RuleFor(x => x.Title, f => f.Commerce.ProductName())
             .RuleFor(x => x.Description, f => f.Commerce.ProductAdjective());
    }
}
