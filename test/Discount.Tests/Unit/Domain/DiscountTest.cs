﻿using System;
using Xunit;

namespace Discount.Tests.Unit.Domain
{
    public class DiscountTest
    {
        [Fact]
        public void RuleDiscount_DateOfBirthDiscountTest()
        {
            var princeInCents = 100;
            var dateOfBrith = DateTime.Now.Date;

            var discount = API.Domain.Discount
                .RuleDiscount(princeInCents, dateOfBrith);

            Assert.Equal(0.05f, discount.Pct);
            Assert.Equal(5, discount.ValueInCents);
        }

        [Fact]
        public void RuleDiscount_NotDiscountTest()
        {
            var princeInCents = 100;
            var dateOfBrith = new DateTime(2000, 01, 01);

            var discount = API.Domain.Discount
                .RuleDiscount(princeInCents, dateOfBrith);

            Assert.Equal(0, discount.Pct);
            Assert.Equal(0, discount.ValueInCents);
        }
    }
}
