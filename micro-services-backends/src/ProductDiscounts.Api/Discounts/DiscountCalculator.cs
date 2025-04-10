namespace ProductDiscounts.Api.Discounts
{
    public class DiscountCalculator
    {
        public DiscountCalculator(DiscountContext context)
        {
            Context = context;
        }

        public DiscountContext Context { get; private set; }

        /// <summary>
        /// Calculates the discount to apply to any product given a context.
        /// The context are the characteristics of the client.
        /// </summary>
        /// <returns>The discount in percentage (%)</returns>
        public int CalculateDiscount()
        {
            return 60 - Context.TotalFines;
        }
    }
}
