using Discount.API.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace Discount.API.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(Guid id);
    }
}
