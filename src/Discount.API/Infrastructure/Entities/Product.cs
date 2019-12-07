using System;

namespace Discount.API.Infrastructure.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public int PriceInCents { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
