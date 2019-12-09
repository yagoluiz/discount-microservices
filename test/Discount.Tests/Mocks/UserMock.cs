using Bogus;
using Discount.API.Infrastructure.Entities;

namespace Discount.Tests.Mocks
{
    public static class UserMock
    {
        public static Faker<User> User =>
            new Faker<User>()
             .RuleFor(x => x.Id, f => f.Random.Guid())
             .RuleFor(x => x.FirstName, f => f.Person.FirstName)
             .RuleFor(x => x.LastName, f => f.Person.LastName)
             .RuleFor(x => x.DateOfBirth, f => f.Person.DateOfBirth);
    }
}
