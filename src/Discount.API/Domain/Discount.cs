using System;

namespace Discount.API.Domain
{
    public class Discount
    {
        private static readonly DateTime _dateBlackFriday = new DateTime(2019, 11, 25);

        public Discount() { }

        private Discount(float pct, int valueInCents)
        {
            Pct = pct;
            ValueInCents = valueInCents;
        }

        public float Pct { get; }
        public int ValueInCents { get; }

        public static Discount RuleDiscount(int priceInCents, DateTime dateOfBirth) =>
            (priceInCents, dateOfBirth, DateTime.Now.Date) switch
            {
                var (price, birth, dateNow) when
                    (birth == dateNow && _dateBlackFriday != dateNow) =>
                        new Discount(0.05f, (int)(price * 0.05f)),

                var (price, _, dateNow) when
                    (_dateBlackFriday == dateNow) =>
                        new Discount(0.10f, (int)(price * 0.10f)),

                (_, _, _) => new Discount(0, 0)
            };
    }
}
