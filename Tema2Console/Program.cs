using Tema2Console.Factory;

namespace Tema2Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Client...");

            var logger = new Logger();
            var hotelReception = new HotelReception(
                logger,
                new FileReader(),
                new ProcessorFactory(logger),
            new OrderDeserializer()
                );
            hotelReception.ProcessOrder();

            if (hotelReception.FinalPrice == 0)
            {
                Console.WriteLine("No order was processed.");
            }
            else
            {
                Console.WriteLine($"Final price for you order: {hotelReception.FinalPrice} RON");
            }
        }
    }
}
