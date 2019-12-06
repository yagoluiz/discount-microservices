using Discount.API.Infrastructure.Entities;
using System.Threading.Tasks;

namespace Discount.API.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string id);
    }
}
