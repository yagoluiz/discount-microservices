using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Discount.API.Infrastructure.Context
{
    public class DiscountContext
    {
        private readonly IConfiguration _configuration;

        public DiscountContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection DiscountConnection =>
            new NpgsqlConnection(_configuration["DiscountConnectionString"]);
    }
}
