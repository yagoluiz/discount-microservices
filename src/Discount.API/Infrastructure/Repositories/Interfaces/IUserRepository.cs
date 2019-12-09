using Discount.API.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace Discount.API.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid id);
    }
}
