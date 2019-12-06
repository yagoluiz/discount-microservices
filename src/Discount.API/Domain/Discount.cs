using System;

namespace Discount.API.Domain
{
    public class Discount
    {
        private readonly DateTime _dateBlackFriday = new DateTime(2019, 11, 25);

        public Discount() { }

        private Discount(float pct, int valueInCents)
        {
            Pct = pct;
            ValueInCents = valueInCents;
        }

        public float Pct { get; }
        public int ValueInCents { get; }

        public Discount RuleDiscount(int priceInCents, DateTime dateOfBirth) =>
            (priceInCents, dateOfBirth, DateTime.Now) switch
            {
                var (price, birth, dateNow) when
                    (birth == dateNow && _dateBlackFriday == dateNow) =>
                        new Discount(0.10f, (int)(price / 0.10f)),

                var (price, birth, dateNow) when
                    (birth == dateNow && _dateBlackFriday != dateNow) =>
                        new Discount(0.05f, (int)(price / 0.05f)),

                (_, _, _) => new Discount(0.0f, 0)
            };
    }
}
