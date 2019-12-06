using Discount.API.Infrastructure.Entities;
using System.Threading.Tasks;

namespace Discount.API.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(string id);
    }
}
