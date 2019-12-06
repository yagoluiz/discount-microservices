using Dapper;
using Discount.API.Infrastructure.Context;
using Discount.API.Infrastructure.Entities;
using Discount.API.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Discount.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DiscountContext _discountContext;

        public UserRepository(DiscountContext discountContext)
        {
            _discountContext = discountContext;
        }

        public async Task<User> GetUserById(string id)
        {
            var query = @"SELECT
                            id,
                            first_name,
                            last_name,
                            date_of_birth
                          WHERE
                             id = @Id";

            return await _discountContext
                .DiscountConnection
                .QueryFirstOrDefaultAsync<User>(query, new { Id = id });
        }
    }
}
