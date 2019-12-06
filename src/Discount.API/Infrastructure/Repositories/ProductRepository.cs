using Dapper;
using Discount.API.Infrastructure.Context;
using Discount.API.Infrastructure.Entities;
using Discount.API.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Discount.API.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DiscountContext _discountContext;

        public ProductRepository(DiscountContext context)
        {
            _discountContext = context;
        }

        public async Task<Product> GetProductById(string id)
        {
            var query = @"SELECT
                            id,
                            price_in_cents,
                            title,
                            description
                          WHERE
                             id = @Id";

            return await _discountContext
                .DiscountConnection
                .QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }
    }
}
