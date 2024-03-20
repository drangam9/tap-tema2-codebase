namespace Tema2Console.Processors
{
    public class RoomOrderProcessor : Processor
    {
        public RoomOrderProcessor(ILogger logger) : base(logger)
        {
        }
        public override decimal Process(Models.Order order)
        {
            logger.Log("Processing Room order...");

            logger.Log("Validating order parameters...");

            if (order.Quantity == 0)
            {
                logger.Log("-Room order must specify Quantity");
                return 0;
            }

            if (order.Price == 0)
            {
                logger.Log("-Room order must specify Price");
                return 0;
            }

            if (string.IsNullOrEmpty(order.ReservationDate))
            {
                logger.Log("-Room order must specify Reservation Date");
                return 0;
            }

            if (!DateTime.TryParseExact(order.ReservationDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var pasedReservationDate))
            {
                logger.Log("-Reservation Date must be a valid date");
                return 0;
            }

            if (pasedReservationDate < DateTime.Now.AddMonths(1))
            {
                return (order.Quantity * order.Price) * 0.9m;
            }
            else if (pasedReservationDate < DateTime.Now.AddMonths(2))
            {
                return (order.Quantity * order.Price) * 0.8m;
            }
            else
            {
                return order.Quantity * order.Price;
            }
        }
    }
}
